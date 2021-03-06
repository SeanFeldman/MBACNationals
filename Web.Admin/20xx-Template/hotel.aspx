<%@ Language="C#" MasterPageFile="~/MBAC.Master" AutoEventWireup="false" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
    <div id="headerImage" style="margin-top:15px;background-size:cover;background-position:center center;height:375px;background-image:url('images/header_image_location.jpg'); "></div>
    <div id="photoCredit"><strong>TODO: description</strong> &bull; Credit: TODO: credit</div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceholder" runat="server">

  <!-- Example row of columns -->
  <div class="row hotel">
    <div class="col-md-2 col-sm-2">
      <ul class="sidebarNav">
        <li>
          <a href="#hotel">Hotel</a>
        </li>
        <li>
          <a href="#restaurants">Local Restaurants</a>
        </li>
      </ul>


    </div>
    <div class="col-md-10 col-sm-10">
      <h2>Location</h2>
      <h4 id="hotel">Sheraton Vancouver Guildford Hotel</h4>
      <div class="row">
        <div class="col-md-3 col-sm-3">
          <img src="images/hotel_logo.png" alt="sheraton logo" />
          <p>
            Visit their website at <a href="http://www.sheratonguildford.com" target="_blank">www.sheratonguildford.com</a>
          </p>
        </div>
        <div class="col-md-9 col-sm-9">
          <img src="images/hotel.jpg" alt="Sheraton Vancouver Guildford Hotel" />
        </div>          
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <h4 id="restaurants">Local Restaurants</h4>
        <img src="images/restaurants.jpg" alt="restaurant map" />
      </div>
    </div>
  </div>
</asp:Content>