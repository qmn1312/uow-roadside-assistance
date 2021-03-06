﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeRequest.aspx.cs" Inherits="uow_roadside_assistance.WebPages.LoggedOn.Customer.MakeRequest" %>

<!DOCTYPE html>
<html>
<head>
     <%--title--%>
    <title>Customer Make Request</title>
    
     <%-- jquery and jquery ui --%>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <%-- Bootstrap 4 --%>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <%--Font Awesome--%>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    
    <%--Page CSS--%>
    <link rel="stylesheet" href="../../../Css/LoggedOn/Customer/CustomerNavBar.css" />
    <link rel="stylesheet" href="../../../Css/LoggedOn/Customer/CustomerMakeRequest.css" />

    <%--Nav Bar Scripts--%>
    <script type="text/javascript" src="../../../Scripts/LoggedOn/Customer/CustomerNavBar.js"></script>

    <%-- Page Scripts --%>
    <script type="text/javascript" src="../../../Scripts/LoggedOn/Customer/OnLoadCustomer.js"></script>
    <script type="text/javascript" src="../../../Scripts/LoggedOn/Customer/CustomerMakeRequest.js"></script>
</head>
<body>
    <%-- Service --%>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WebPages/LoggedOn/Customer/CustomerService.svc" />
        </Services>
    </asp:ScriptManager>
    </form>

    <%-- Navigation Bar --%>
    <div id="navigationBar" class="container-fluid">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div id="navbarNavDropdown" class="navbar-collapse collapse">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="navbar-brand" href="CustomerHomepage.aspx">
                            <img src="../../../Images/official_logo.gif" width="60" height="60"/><span id="logoText">Daedalus Customer</span>
                        </a>
                    </li>
                </ul>
                <ul class="navbar-nav">
                        
                    <li class="nav-item dropdown">
                        <a id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <span id="UserNameLabel"></span>
                            <i class="fas fa-user-circle fa-2x"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right text-right" aria-labelledby="dropdownMenuButton">
                            <a class="dropdown-item" href="CustomerHomepage.aspx">Dashboard</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="CustomerProfile.aspx">Profile</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="CustomerPastTransactions.aspx">Past transactions</a>
                            <div class="dropdown-divider"></div>
                            <a id="logOutLink" class="dropdown-item">Logout <i class='fas fa-sign-out-alt'></i></a> 
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
    </div>

    <%-- Page Content --%>

    <div style="margin-left:15%; width: 70%">
        <br />
        <div class="headerDetails">
            <h2>
                <span class="underlinedText" style="text-align:center">
                    Request For Road Assistance
                </span>
                <span class="icon"><i class='fas fa-tools' style='font-size:36px'></i></span>
            </h2>
        </div>
        <br /><br />
        <div class="container-fluid">
            <div class="headerDetails">
                <h3><i>Problem Type: </i></h3>
            </div>
            <br />
            <%-- Row 1 --%>
            <div class="row">
                <div class="col">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-4 text-right" >
                                <input id="TyreCheckBox" type="checkbox" />
                            </div>
                            <div class="col">
                                <img id="TyreProblem" class="problemType" src="../../../Images/Customer/ProblemType/tyre.png"/>
                                <br />
                                <span id="TyreLabel" class="problemLabel">Tyre</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-4 text-right" >
                                <input id="CarBatteryCheckBox" type="checkbox" />
                            </div>
                            <div class="col">
                                <img id="CarBatteryProblem" class="problemType" src="../../../Images/Customer/ProblemType/carBattery.png"/>
                                <br />
                                <span id="CarBatteryLabel" class="problemLabel">Car Battery</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <br /><br />

            <%-- Row 2 --%>
            <div class="row">
                <div class="col">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-4 text-right" >
                                <input id="EngineCheckBox" type="checkbox" />
                            </div>
                            <div class="col">
                                <img id="EngineProblem" class="problemType" src="../../../Images/Customer/ProblemType/engine.png"/>
                                <br />
                                <span id="EngineLabel" class="problemLabel">Engine</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-4 text-right" >
                                <input id="GeneralCheckBox" type="checkbox" />
                            </div>
                            <div class="col">
                                <img id="GeneralProblem" class="problemType" src="../../../Images/Customer/ProblemType/general.png"/>
                                <br />
                                <span id="GeneralLabel" class="problemLabel">General</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <br /> <br />

            <%-- Description --%>
            <div class="headerDetails">
                <h3><i>Description: </i></h3>
            </div>

            <br />
            <div>
                <textarea id="Description" class="form-control" rows="10" placeholder="Please write a short description of your problem"></textarea>
            </div>

            <br /><br />
            <%-- Location --%>
            <div class="headerDetails">
                <h3><i>Location: </i></h3>
            </div>

        </div>
    </div>
    
    <%-- Choose Location --%>
    <br />
    <div style ="width:70%; margin-left:15%">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-6">
                    <input id="searchAddressText" class="form-control" type="text" placeholder="Choose your current location" />
                    <span id="searchAddressErrMess" class="ErrorMessage"></span>
                </div>
                <div class="col">
                    <button id="searchAddressButton" class="btn btn-outline-light" data-toggle="tooltip" data-placement="top" title="Re-center location">
                        <i class="fas fa-map-marker-alt fa-lg" style="color: red"></i>
                    </button>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-6">
                    <div>
                        <div class="row">
                            <div class="col">
                                <input id="nearByRadius" class="form-control" type="text" placeholder="Within area..." />
                            </div>
                            <div class="col">
                                <select id="nearByUnit" class="form-control">
                                    <option>Kilometers</option>
                                    <option>Meters</option>
                                </select>
                            </div>
                        </div>
                        <span id="nearByRadiusErrMess" class="ErrorMessage"></span>
                    </div>
                </div>
                <div class="col">
                    <button id="nearBySearchButton" class="btn btn-outline-light" data-toggle="tooltip" data-placement="top" title="Nearby Search">
                        <i class="far fa-dot-circle fa-lg" style="color: blue"></i>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <%-- GOOGLE MAPS --%>
    <div id="map" style ="width:68%; height: 600px; margin-top:50px; margin-left:16%"></div>
    <br />

    

    <br /><br />

    <%-- SUBMIT --%>
    <div style="margin-left:16%; width: 68%; text-align:center">
        <button id="RequestButton" class="btn btn-info">REQUEST</button>
    </div>

    <br /><br />
    <script>
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBbzUiNGypGLKksqci8ZJpNTrJ-JNqAFJA&callback=initMap&libraries=places"
    async defer></script>
  </body>
</html>


<%--var citymap = {
        canberra: {
          center: {lat: -35, lng: 149.15}, // 100km
          population: 8405837
        },
        sydney: {
          center: {lat: -33, lng: 150}, // 100 km
          population: 3857799
        },
        wollongong: {
          center: {lat: -34.414321, lng: 150.884085}, 
          population: 603502
        }
      };
    
 <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBbzUiNGypGLKksqci8ZJpNTrJ-JNqAFJA&callback=initMap&libraries=places">
    </script>   
 --%>