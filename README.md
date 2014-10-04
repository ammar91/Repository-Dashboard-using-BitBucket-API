Repository-Dashboard-using-BitBucket-API
========================================
This project has been designed to Build a Simple Dashboard using BitBucket API. The Dashboard will include a list of 
Repositories associate with the Account, Commit History and a list of Issues that has been created. New Issues can
be create and existing issues can be modify directly without Login to BitBucket Acccount.

The Project divided into 4 separate layers.

1) BitBucketGateway:  
   
   Handles authenticating with the API and create the instance needed and expose the calls we make to it. 
    
2) BitBucketService:

  It has methods and business logic the application uses to send to the gateway layer.
  
3) BitBucketWeb: (The User Interface - MVC5 Web Application)

4) Common: 

  It is designed for perofrming common operations like Sending an Email to the Repository owner whenever a new activity 
  has been performed like on "creating new issue".


Configuration Needed.

Inside web.config of 'BitBucketWeb' there is a need to setup ConsumerKey and ConsumerSecret of BitBucket Consumer under <appSetting>

<add key="ConsumerKey" value="" />
<add key="ConsumerSecret" value="" />

In order to receive email notification of new activity, add your email

<add key="EmailNotifications" value="" />

Also, set credentials from which user's get notified

<network host="smtp.gmail.com" port="25" userName="" password="" enableSsl="true" targetName="BitBucket App" />
