<%@ Language="C#" MasterPageFile="~/MBAC.Master" AutoEventWireup="false" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
    <div id="headerImage" style="margin-top: 15px; background-size: cover; background-position: center center; height: 375px; background-image: url('images/header_image_2.jpg');"></div>
    <div id="photoCredit"><strong>Holland Park, Surrey, BC</strong> &bull; Credit: Waferboard, Flickr Commons</div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="col-md-2">
        <ul class="sidebarNav">
            <li><a href="#cloverdale">Clover Lanes - Cloverdale</a></li>
            <li><a href="#scottsdale">Scottsdale Lanes - Surrey</a></li>
            <li><a href="#willowbrook">Willowbrook Lanes - Langley</a></li>
        </ul>

    </div>
    <div class="col-md-10">
        <h2>centres</h2>
        <h4 id="cloverdale">Clover Lanes - Cloverdale</h4>

        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-3 centreLogo">
                    <img src="images/Clover.jpg" alt="Clover Lanes" />
                </div>
                <div class="col-md-9 col-sm-9 centreDetails">
                    <p>
                        <strong>604-574-4601<br />
                            5814 - 176A Street, Surrey, BC<br />
                        </strong>
                        For more information, check out their website: <a href="http://surreybowling.com" target="_blank">http://surreybowling.com</a>
                    </p>
                </div>
            </div>
        </div>
        <h4 id="scottsdale">Scottsdale Lanes - Surrey</h4>

        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-3 centreLogo">
                    <img src="images/Scottsdale.jpg" alt="Scottsdale Lanes" />
                </div>
                <div class="col-md-9 col-sm-9 centreDetails">
                    <p>
                        <strong>604-596-3924<br />
                            12033 - 84th Avenue, Surrey, BC<br />
                        </strong>
                        For more information, check out their website: <a href="http://www.scottsdalelanes.com" target="_blank">http://www.scottsdalelanes.com</a>
                    </p>

                </div>
            </div>
        </div>
        <h4 id="willowbrook">Willowbrook Lanes - Willowbrook</h4>

        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-3 centreLogo">
                    <img src="images/Willowbrook.jpg" alt="Willowbrook Lanes" />
                </div>
                <div class="col-md-9 col-sm-9 centreDetails">
                    <p>
                        <strong>604-533-2695<br />
                            6350 - 196th Street, Langley, BC</strong><br />
                        For more information, check out their website: <a href="http://willowbrooklanes.ca" target="_blank">http://willowbrooklanes.ca</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
