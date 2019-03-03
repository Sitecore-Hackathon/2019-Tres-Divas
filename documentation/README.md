# Documentation

The purpose of this module is to revolutionize the way product reviews are submitted and to provide a way to aggregate all reviews for a product in one place. Currently, product reviews can be found scattered across various resellers of the product with little or no sharing.
Using Twitter tweets as a backdrop, we propose that reviews be submitted directly to the manufacturer.

## Summary

**Category:** Best Use of Universal Tracker

What is the purpose of your module? What problem does it solve and how does it do that?

Usually the product reviews are scattered across and it is usually hard to aggregate them.  The purpose of this module is to solve the aggregation problem by providing specific twitter hash tag for the product.
This can then we used by the end user to tweet about the product.  We then have a listener that listens to the tweets and pushes the events to Universal tracker. 
The journey of the information/event will continue to go to XConnect and an outcome is created. Outcomes are identified by twitter handle and carry information about the tweet and sentiment. 

In our example, we consider a example of a Best kitchen with three products and three unique hashtags one for each. 

 - BestBarista Coffee Grinder = #bestbaristacoffeegrinder
 - PerfectSmoothie Blender = #perfectsmoothieblender
 - SunBright Toaster = #sunbrighttoaster

We hear for live tweets flowing with these hashtags and capture the interactions and outcomes to solve the problem of scattered reviews.
What we also do is leverage Universal tracker ability to filter out tweets that are not 

Currently, we are looking for below settings to determine if a tweet is important enough to be considered as interaction.  These settings are stored on Sitecore to ensure this idea can be extended.

- Age of Twitter account
- Minimum number of followers
- Is it a retweet or no?

On the aggregation side of things, we believe as with any reviews the end user is interested in understanding how the product is overall. 
Here it gets important to showcase the reviews bucketing them in to positive, neutral or negative.  We leveraged Text Analyzer from Microsoft [direct link](https://azure.microsoft.com/en-us/services/cognitive-services/text-analytics/) Cognitive Services to get the Sentiment and came up with ranges based on Sentiment that we think would determine where the review fits.

Ranges Defined currently and potentially can be modified with help of data science behind them


- Postive Range  = { 0.8, 1}
- Negative Range = {0, 0.2}
- Neutral Range = {0.2, 0.5}
         
         

## Pre-requisites

Does your module rely on other Sitecore modules or frameworks?

- Sitecore 9.1 - Ensure all pre-requisites for 9.1 are in check [direct link](https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform/91/Sitecore_Experience_Platform_91_Initial_Release.aspx)
- Installation of Universal Tracker 
- To Avoid any modifications of config files and patches please name your sitecore instance as ut.hackathon.com


## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

1. Clone master branch of Tres Divas repository [direct link](https://github.com/Sitecore-Hackathon/2019-Tres-Divas.git)
2. Check the values on TDSGlobal.config located in root directory to ensure it is correct per your installation
3. Rebuild solution and ensure all Nuget packages are rebuilt
4. SYNC all TDS items in TDS projects included in the solution
5. Right click on TresDivas.Website project and publish to your local website root

## Configuration

The below steps would be needed to ensure the solution works 

- Take the file located and checked in under 2019-Tres-Divas\src\Project\Console\code\TresDivas.ModelGeneration.Console\data and drop in to below locations under your website directories
    --C:\inetpub\wwwroot\hackathon.xconnect\App_Data\jobs\continuous\IndexWorker\App_data\Models
    --C:\inetpub\wwwroot\hackathon.xconnect\App_Data\Models
- Go to below project under location 2019-Tres-Divas\src\Feature\TresDivas\code\TresDivas.SocialInteractions.Processing 
    -- Update the constants.cs and put in the values for XConnectThumbprint and XConnectInstance to match the local values
    -- Reference below
```
namespace TresDivas.SocialInteractions.Processing
{
    public class Constants
    {
        public const string XConnectThumbprint = "D77AAB9D28CBDD254D52DFFB3F32096DAEA05D7B";
        public const string XConnectInstance = "https://xconnect.ut.hackathon.com";
    }
}
```
- Do the steps shown below in screenshots 

![Services](images/Services.png?raw=true "Service Change")

![Folder Swap](images/FolderSwap.png?raw=true "Folder Swap")

- After this manual steps restart all associated services including xconnect

## Future Scope

- Retailers to display product reviews on their pages via distributed x-connect device
- Check back on this account to see if more followers using the required age of account and then delete this if threshold is still not met.
- Expand to other social community channels like Facebook and Instagram and accept product lifestyle comments.
- Product Registration will allow users to register via tweet to consider them verified in the future so we ensure only qualified users can leave reviews



## About Us 


![TresDivas](images/TresDivas.jpg?raw=true "TresDivas Logo")


## Video

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
