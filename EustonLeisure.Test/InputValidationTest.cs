using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EustonLeisure.Test
{
    /// <summary>
    /// Test class used for unit testing of EustonLeisure application.
    /// </summary>
    [TestClass]
    public class InputValidationTest
    {
        [TestClass]
        public class EmailValidationTest
        {
            [TestMethod]
            public void WhenInputIsValid_ShouldCreateEmail()
            {
                string sender = "jacek@jacek.com";
                string subject = "Some subject";
                string message = "Hey, it's me sending email!";

                EmailMessage email = null;

                try
                {
                    email = new EmailMessage(sender, subject, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                bool expectedResponse = true;
                var isValid = email != null;

                Assert.AreEqual(expectedResponse, isValid);
            }

            [TestMethod]
            public void WhenInputIsInvalid_ShouldNotCreateEmail()
            {
                string sender = "jacek.jacek.com";
                string subject = "Some subject";
                string message = "Hey, it's me sending invalid email!";

                EmailMessage email = null;

                try
                {
                    email = new EmailMessage(sender, subject, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                bool expectedResponse = false;
                var isValid = email != null;

                Assert.AreEqual(expectedResponse, isValid);
            }

            [TestMethod]
            public void WhenValidSirSend_ShouldCreateEmail()
            {
                string sender = "jacek@jacek.com";
                string subject = "SIR 21/07/17";
                string message = "55-123-53\nBomb Threat\nPlease help!";

                EmailMessage email = null;

                try
                {
                    email = new EmailMessage(sender, subject, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                bool expectedResponse = true;
                var isValid = email != null;

                Assert.AreEqual(expectedResponse, isValid);
            }

            [TestMethod]
            public void WhenInvalidSirSend_ShouldNotCreateEmail()
            {
                string sender = "jacek@jacek.com";
                string subject = "SIR 12/15/11";
                string message = "55-13-53\nBomb Threat\nPlease help!";

                EmailMessage email = null;

                try
                {
                    email = new EmailMessage(sender, subject, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                bool expectedResponse = false;
                var isValid = email != null;

                Assert.AreEqual(expectedResponse, isValid);
            }
        }
       
        [TestClass]
        public class SmsValidationTest
        {
            [TestMethod]
            public void WhenInputIsValid_ShouldCreateSms()
            {
                string sender = "07947676706";
                string message = "Hey, it's me sending SMS!";

                SmsMessage sms = null;

                try
                {
                    sms = new SmsMessage(sender, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                bool expectedResponse = true;
                var isValid = sms != null;

                Assert.AreEqual(expectedResponse, isValid);
            }

            [TestMethod]
            public void WhenInputIsInvalid_ShouldNotCreateSms()
            {
                string sender = "12345";
                string message = "Hey, it's me sending invalid SMS!";

                SmsMessage sms = null;

                try
                {
                    sms = new SmsMessage(sender, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                bool expectedResponse = false;
                var isValid = sms != null;

                Assert.AreEqual(expectedResponse, isValid);
            }

            [TestMethod]
            public void WhenTextspeakAbbreviationsPresent_ShouldExpandThem()
            {
                string sender = "07947676706";
                string message = "Hey, HRU it's me sending valid SMS LOL!";

                SmsMessage sms = new SmsMessage(sender, message);

                string expectedResponse = "Hey, HRU <How are you?> it's me sending valid SMS LOL <Laughing out loud>!";
                string actualResponse = sms.Body;

                Assert.AreEqual(expectedResponse, actualResponse);
            }
        }

        [TestClass]
        public class TweetValidationTest
        {
            [TestMethod]
            public void WhenInputIsValid_ShouldCreateTweet()
            {
                string sender = "@Jacek";
                string message = "Hey, it's me sending Tweet!";

                TweetMessage tweet = null;

                try
                {
                    tweet = new TweetMessage(sender, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                bool expectedResponse = true;
                var isValid = tweet != null;

                Assert.AreEqual(expectedResponse, isValid);
            }

            [TestMethod]
            public void WhenInputIsInvalid_ShouldNotCreateTweet()
            {
                string sender = "@Jaceeeeeeeeeeeeeeeeeeeeeeeeeeeeek";
                string message = "Hey, it's me sending invalid Tweet!";

                TweetMessage tweet = null;

                try
                {
                    tweet = new TweetMessage(sender, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                bool expectedResponse = false;
                var isValid = tweet != null;

                Assert.AreEqual(expectedResponse, isValid);
            }
        }

        [TestClass]
        public class LoadingInputFromFileTest
        {
            [TestMethod]
            public void WhenInputIsValid_ShouldCreateMessages()
            {
                string path = "C:\\Napier\\Software Engineering\\coursework\\message unprocessed.json";

                Dictionary<Utils.MessageWrapper, Message> messages = new Dictionary<Utils.MessageWrapper, Message>();

                try
                {
                    messages = Utils.DeserializeFromJson(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                int expectedCount = 5;
                int actualCount = messages.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [TestMethod]
            public void WhenFileIsInvalid_ShouldNotCreateMessages()
            {
                string path = "C:\\Napier\\Software Engineering\\coursework\\nosuchfile.json";

                Dictionary<Utils.MessageWrapper, Message> messages = new Dictionary<Utils.MessageWrapper, Message>();

                try
                {
                    messages = Utils.DeserializeFromJson(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                int expectedCount = 0;
                int actualCount = messages.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [TestMethod]
            public void WhenMessagesSupplied_ShouldSaveThemToFile()
            {
                List<Message> messages = new List<Message> { new SmsMessage("07947676706", "hey, save me!") };
                string path = "C:\\Napier\\Software Engineering\\messages.json";

                Dictionary<Utils.MessageWrapper, Message> messagesFromFile = new Dictionary<Utils.MessageWrapper, Message>();

                try
                {
                    Utils.SerializeToJson(messages);

                    messagesFromFile = Utils.DeserializeFromJson(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                int expectedResult = 1;
                int actualResult = messagesFromFile.Count;

                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestClass]
        public class UpdatingListsTest
        {
            [TestMethod]
            public void WhenHashtagAdded_ShouldStoreItInTrendingList()
            {
                string sender = "@Jacek";
                string hashtag = "#EdinburghNapier";
                string message = "Hey, it's me putting hashtag! " + hashtag;

                TweetMessage tweet = new TweetMessage(sender, message);

                bool expectedResult = true;
                bool actualResult = TrendingForm.HashTags.Contains(hashtag);

                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void WhenMentionAdded_ShouldStoreItInMentionsList()
            {
                string sender = "@Jacek";
                string mention = "@Napier";
                string message = "Hey, it's me mentioning " + mention;

                TweetMessage tweet = new TweetMessage(sender, message);

                bool expectedResult = true;
                bool actualResult = MentionsForm.Mentions.Contains(mention);

                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void WhenValidSirSend_ShouldStoreDetailsInSirList()
            {
                string sender = "jacek@jacek.com";
                string subject = "SIR 21/07/17";
                string centreCode = "55-123-53";
                string natureOfIncident = "Raid";
                string message = centreCode + "\n" + natureOfIncident + "\nPlease help!";

                EmailMessage email = new EmailMessage(sender, subject, message);

                SeriousIncident sir = new SeriousIncident(centreCode, natureOfIncident);

                bool expectedResult = true;
                bool actualResult = SirForm.SeriousIncidents.Exists(incident => incident.Equals(sir));

                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
