﻿using Edument.CQRS;
using MBACNationals.ReadModels;
using MBACNationals.Participant;
using MBACNationals.Contingent;
using System.IO;
using System.Web;
using MBACNationals.Scores;
using MBACNationals;
using MBACNationals.Tournament;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using System.Threading;
using System;
using Newtonsoft.Json;
using AzureTableHelper;

namespace WebFrontend
{
    public static class Domain
    {
        public static MessageDispatcher Dispatcher;
        public static ICommandQueries CommandQueries;
        public static IParticipantQueries ParticipantQueries;
        public static IParticipantProfileQueries ParticipantProfileQueries;
        public static IContingentViewQueries ContingentViewQueries;
        public static IContingentTravelPlanQueries ContingentTravelPlanQueries;
        public static IContingentPracticePlanQueries ContingentPracticePlanQueries;
        public static IReservationQueries ReservationQueries;
        public static IScheduleQueries ScheduleQueries;
        public static IMatchQueries MatchQueries;
        public static IStandingQueries StandingQueries;
        public static IHighScoreQueries HighScoreQueries;
        public static IParticipantScoreQueries ParticipantScoreQueries;
        public static ITeamScoreQueries TeamScoreQueries;
        public static ITournamentQueries TournamentQueries;
        public static IStepladderQueries StepladderQueries;

        public static void Setup()
        {            
            Dispatcher = new MessageDispatcher(new SqlEventStore(Properties.Settings.Default.DefaultConnection));

            CommandQueries = new CommandQueries();
            Dispatcher.ScanInstance(CommandQueries);

            Dispatcher.ScanInstance(new ParticipantCommandHandlers(CommandQueries));
            Dispatcher.ScanInstance(new ContingentCommandHandlers(CommandQueries));
            Dispatcher.ScanInstance(new ScoresCommandHandlers(CommandQueries, Dispatcher)); //TODO: Refactor Dispatcher out of Handler
            Dispatcher.ScanInstance(new TournamentCommandHandlers(CommandQueries));

            ParticipantQueries = new ParticipantQueries();
            Dispatcher.ScanInstance(ParticipantQueries);

            ParticipantProfileQueries = new ParticipantProfileQueries();
            Dispatcher.ScanInstance(ParticipantProfileQueries);

            ContingentViewQueries = new ContingentViewQueries();
            Dispatcher.ScanInstance(ContingentViewQueries);

            ContingentTravelPlanQueries = new ContingentTravelPlanQueries();
            Dispatcher.ScanInstance(ContingentTravelPlanQueries);

            ContingentPracticePlanQueries = new ContingentPracticePlanQueries();
            Dispatcher.ScanInstance(ContingentPracticePlanQueries);

            ReservationQueries = new ReservationQueries();
            Dispatcher.ScanInstance(ReservationQueries);

            ScheduleQueries = new ScheduleQueries();
            Dispatcher.ScanInstance(ScheduleQueries);

            MatchQueries = new MatchQueries();
            Dispatcher.ScanInstance(MatchQueries);

            StandingQueries = new StandingQueries();
            Dispatcher.ScanInstance(StandingQueries);

            HighScoreQueries = new HighScoreQueries();
            Dispatcher.ScanInstance(HighScoreQueries);

            ParticipantScoreQueries = new ParticipantScoreQueries();
            Dispatcher.ScanInstance(ParticipantScoreQueries);

            TeamScoreQueries = new TeamScoreQueries();
            Dispatcher.ScanInstance(TeamScoreQueries);

            TournamentQueries = new TournamentQueries();
            Dispatcher.ScanInstance(TournamentQueries);

            StepladderQueries = new StepladderQueries();
            Dispatcher.ScanInstance(StepladderQueries);
        }

        public static void RebuildReadModel(string readmodel)
        {
            var untypedModel = typeof(Domain).GetField(readmodel).GetValue(null);
            if (untypedModel is IReadModel)
            {
                var instance = ((IReadModel)untypedModel);

                instance.Reset();
                Dispatcher.RegenerateReadModel(readmodel);
                instance.Save();
            }
            else
            {
                GoOffline();

                var tableStorageConn = ConfigurationManager.ConnectionStrings["AzureTableStorage"].ConnectionString;
                var storageAccount = CloudStorageAccount.Parse(tableStorageConn);
                var tableClient = storageAccount.CreateCloudTableClient();

                var azureTableHelper = new AzureTableHelper.AzureTableHelper(tableClient);
                var originalTableName = azureTableHelper.GetTableNameFor(readmodel.ToLower());
                azureTableHelper.IterateTableNameFor(readmodel.ToLower());

                Dispatcher.RegenerateReadModel(readmodel);

                GoOnline();

                azureTableHelper.DeleteTable(originalTableName);
            }
        }

        public static void RebuildSchedule()
        {
            ScheduleBuilder.TournamentMenSingle(CommandQueries, Dispatcher);
            ScheduleBuilder.TournamentLadiesSingle(CommandQueries, Dispatcher);
            ScheduleBuilder.TournamentLadies(CommandQueries, Dispatcher);
            ScheduleBuilder.TournamentMen(CommandQueries, Dispatcher);
            ScheduleBuilder.TeachingLadies(CommandQueries, Dispatcher);
            ScheduleBuilder.TeachingMen(CommandQueries, Dispatcher);
            ScheduleBuilder.Seniors(CommandQueries, Dispatcher);
        }

        public static void RebuildQualifyingPositions()
        {
            //HACK: This is a one time fix for environments to historically add missing Qualifying Position events
            QualifyingPositionFixer.Execute(CommandQueries, ContingentViewQueries, Dispatcher);
        }

        private static void GoOffline()
        {
            var bakFile = HttpContext.Current.Server.MapPath("~/app_offline.bak");
            var htmFile = HttpContext.Current.Server.MapPath("~/app_offline.htm");
            File.Copy(bakFile, htmFile, true);
        }

        private static void GoOnline()
        {
            var htmFile = HttpContext.Current.Server.MapPath("~/app_offline.htm");
            File.Delete(htmFile);
        }
    }
}