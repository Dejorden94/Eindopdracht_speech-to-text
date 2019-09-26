using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;


namespace helloworld
{
    class Program
    {
        public static async Task RecognizeSpeechAsync()
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription("subscriptionKey", "Region");

            // Creates a speech recognizer.
            using (var recognizer = new SpeechRecognizer(config))
            {
                Console.WriteLine("Say something...");

                // Starts speech recognition, and returns after a single utterance is recognized. The end of a
                // single utterance is determined by listening for silence at the end or until a maximum of 15
                // seconds of audio is processed.  The task returns the recognition text as result. 
                // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
                // shot recognition like command or query. 
                // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead (RecognizeOnceAsync()).
                var result = await recognizer.RecognizeOnceAsync();

                // Checks result.
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                Console.WriteLine($"We recognized: {result.Text}");
                    if (System.Text.RegularExpressions.Regex.IsMatch(result.Text, @"[*]")){ //Reguliere expressie die zoekt naar een *, als die wordt gevonden dan print de console "DOE EVEN NORMAAL!"
                        Console.WriteLine($"DOE IS EVEN NORMAAL!");
                    }
                    else{
                        Console.WriteLine("Text herkend"); //Als er geen * wordt gevonden dan print de console gewoon "text herkend"
                    }
                    /*switch (result.Text)
                    {
                        case "***":
                            Console.WriteLine($"STOP SWEARING!");
                            break;
                        case "****":
                            Console.WriteLine($"STOP SWEARING!");
                            break;
                        case "*****":
                            Console.WriteLine($"STOP SWEARING!");
                            break;
                        case "******":
                            Console.WriteLine($"STOP SWEARING!");
                            break;
                        case "*******":
                            Console.WriteLine($"STOP SWEARING!");
                            break;
                        default:
                            Console.WriteLine("You didn't swear! Nice.");
                            break;
                    }*/
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }
        }

        static void Main()
        {
            RecognizeSpeechAsync().Wait();
            Console.WriteLine("Please press a key to continue.");
            Console.ReadLine();
        }
    }
}