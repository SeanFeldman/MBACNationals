﻿using Edument.CQRS;
using Events.Tournament;
using System;
using System.Collections.Generic;

namespace MBACNationals.Tournament
{
    public class TournamentAggregate : Aggregate,
        IApplyEvent<TournamentCreated>,
        IApplyEvent<SponsorCreated>,
        IApplyEvent<SponsorDeleted>,
        IApplyEvent<SponsorPositionChanged>,
        IApplyEvent<NewsCreated>,
        IApplyEvent<NewsDeleted>,
        IApplyEvent<HotelCreated>,
        IApplyEvent<HotelDeleted>,
        IApplyEvent<GuestPackageSaved>,
        IApplyEvent<CentreCreated>,
        IApplyEvent<CentreDeleted>
    {
        public string Year { get; private set; }

        public void Apply(TournamentCreated e)
        {
            Year = e.Year;
        }

        public void Apply(SponsorCreated e)
        {
            //TODO: nothing at this time
        }

        public void Apply(SponsorDeleted e)
        {
            //TODO: nothing at this time
        }

        public void Apply(SponsorPositionChanged e)
        {
            //TODO: nothing at this time
        }

        public void Apply(NewsCreated e)
        {
            //TODO: nothing at this time
        }

        public void Apply(NewsDeleted e)
        {
            //TODO: nothing at this time
        }
    
        public void Apply(HotelCreated e)
        {
            //TODO: nothing at this time
        }

        public void Apply(HotelDeleted e)
        {
            //TODO: nothing at this time
        }
    
        public void Apply(GuestPackageSaved e)
        {
            //TODO: nothing at this time
        }

        public void Apply(CentreCreated e)
        {
            //TODO: nothing at this time
        }

        public void Apply(CentreDeleted e)
        {
            //TODO: nothing at this time
        }
    }
}
