<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Home</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="scss/main.css">
    <link rel="stylesheet" href="scss/skin.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
    <script src="./script/index.js"></script>
</head>

<body id="wrapper">

    <section id="top-header">
        
        </div>

    </section>

    <header>
        <nav class="navbar navbar-inverse">
            <div class="container">
                <div class="row">

                 <div class="navbar-header">
                    
                    <a class="navbar-brand" href="#">
                       <h1>Secure </h1><span>Data Sharing  </span></a>
                </div>
                    
                    <div id="navbar" class="collapse navbar-collapse navbar-right">
                        <ul class="nav navbar-nav">
                      
                        <li><a href="Home.aspx">Home</a></li>
                         <li><a href="CALogin.aspx">CALogin</a></li>
                        <li><a href="AdminLogin.aspx">AdminLogin</a></li>
                        <li><a href="NewAdmin.aspx">NewAdmin</a></li>
                        <li><a href="UserLogin.aspx">UserLogin</a></li>
                         <li><a href="NewUser.aspx">NewUser</a></li>
                      
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </div>
        </nav>
    </header>
    <!--/.nav-ends -->

    <div id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <div class="fill" style="background-image:url('img/banner-slide-1.jpg');"></div>
                
            </div>

            <div class="item">
                <div class="fill" style="background-image:url('img/banner-slide-2.jpg');"></div>
                
            </div>

            <div class="item">
                <div class="fill" style="background-image:url('img/banner-slide-3.jpg');"></div>
                
            </div>
        </div>

        <!-- Left and right controls -->

      

    </div>

        <section id="features">
        <div class="container">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>

    </div>
    </section>



    <section id="bottom-footer">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-sm-6 col-xs-12 btm-footer-links">
                    <a href="#">Privacy Policy</a>
                    <a href="#">Terms of Use</a>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12 copyright">
                     <a href="#">Secure</a> Data Sharing <a href="#"></a>
                </div>
            </div>
        </div>
    </section>

    


</body>
</html>
