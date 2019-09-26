# Eindopdracht_speech-to-text

This app converts speech to text and gives a notification when the user is cursing.

To use the app you must clone this repository and save it somewhere on your computer. 

Open the Program.cs file and do the following:

First of all I recommend that you use visual studio to run this project.

In the ``` var config = SpeechConfig.FromSubscription("SubscriptionKey", "Region");``` line you have to enter your subscription key 
from Microsoft Azure speech services and your region (If you are using a trial subscription key you have to enter “westus” at region.)

If you purchased the speech to tekst key you can find you region here: https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/regions

When you have done all this you can click Build > Build solution, next up you can click on Debug > Start Debugging and the project will start
 
When you start to talk the software it will listen to what you are saying, when you stop talking the software will return what you said. If you say any curse words then the software will notify you that you must watch your language.

For more information about the project you can look at the wiki https://github.com/Dejorden94/Eindopdracht_speech-to-text/wiki

