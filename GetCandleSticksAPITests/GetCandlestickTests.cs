using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GetCandleSticksAPITests
{
    public class GetCandlestickTests
    {
        private HttpResponseMessage httpResponseMessage;
        
        [Test]
        [TestCase("BTC_USDT", "1m")]
        [TestCase("BTC_USDT", "5m")]
        [TestCase("BTC_USDT", "15m")]
        [TestCase("BTC_USDT", "30m")]
        [TestCase("BTC_USDT", "1h")]
        [TestCase("BTC_USDT", "4h")]
        [TestCase("BTC_USDT", "6h")]
        [TestCase("BTC_USDT", "12h")]
        [TestCase("BTC_USDT", "1D")]
        [TestCase("BTC_USDT", "7D")]
        [TestCase("BTC_USDT", "14D")]
        [TestCase("BTC_USDT", "1M")]

        [TestCase("ETH_CRO", "1m")]
        [TestCase("ETH_CRO", "5m")]
        [TestCase("ETH_CRO", "15m")]
        [TestCase("ETH_CRO", "30m")]
        [TestCase("ETH_CRO", "1h")]
        [TestCase("ETH_CRO", "4h")]
        [TestCase("ETH_CRO", "6h")]
        [TestCase("ETH_CRO", "12h")]
        [TestCase("ETH_CRO", "1D")]
        [TestCase("ETH_CRO", "7D")]
        [TestCase("ETH_CRO", "14D")]
        [TestCase("ETH_CRO", "1M")]
        public async Task Given_A_Valid_Request_Then_A_200_OK_Response_Is_Returned_And_CandleStick_Data_Is_Returned(string instrumentName, string timeFrame)
        {
            // Arrange
            this.httpResponseMessage = new HttpResponseMessage();

            // Act
            var result = await RequestClient.Get(instrumentName, timeFrame);

            var readAsStringAsync = await this.httpResponseMessage.Content.ReadAsStringAsync();

            // Assert
            Assert.That(this.httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            //Assert that code is equal to 0
            //Assert that method is equal to "public/get-candlestick"
            //Assert that "instrument_name" is same as what we passed in
            //Assert that depth is equal to 1000
            //Assert that "interval" is same as what we passed in
            //Assert that result.data[] contains 6 elements
            //Assert that values contained in result.data[] are not null
            //Assert on the response headers counts
            //Assert "Content-Type" on response header is equal to "application/json"

        }

        [Test]
        [TestCase("1BTC_USDT", "1m")]

        public async Task Given_A_Valid_Request_With_Non_Existence_Instrument_Name_Then_A_200_OK_Response_Is_Returned_And_No_Candlestick_Data_Is_Returned(string instrumentName, string timeFrame)
        {
        //Arrange
        this.httpResponseMessage = new HttpResponseMessage();

        // Act
        var result = await RequestClient.Get(instrumentName, timeFrame);

        // Assert
        Assert.That(httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //Assert that code is equal to 0
        //Assert that method is equal to "public/get-candlestick"
        //Assert that "instrument_name" is same as what we passed in
        //Assert that depth is equal to 1000
        //Assert that "interval" is same as what we passed in
        //Assert that result.data[] is null
        }

        [Test]
        [TestCase("-BTC_USDT", "1m")]
        public async Task Given_An_Invalid_Instrument_Name_Then_A_200_OK_Response_And_Error_Message_Is_Returned(string instrumentName, string timeFrame)
        {
        // Arrange
        this.httpResponseMessage = new HttpResponseMessage();

        // Act
        var result = await RequestClient.Get(instrumentName, timeFrame);

        // Assert
        Assert.That(httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //Assert that code is equal to 10004
        //Assert that result is null
        //Assert that message is equal to "Invalid input"
        }

        [Test]
        [TestCase(null,"1m")]
        public async Task Given_Instrument_Name_Is_Not_Provided_Then_A_400_Bad_Request_Response_Is_Returned_And_Error_Message_Is_Returned(string instrumentName,string timeFrame)
        {
            // Arrange
            this.httpResponseMessage = new HttpResponseMessage();

            // Act
            var result = await RequestClient.Get(instrumentName, timeFrame);

            // Assert
            Assert.That(httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //Assert that "timestamp" is not null
            //Assert that path is equal to "public/get-candlestick"
            //Assert that status is equal to 400
            //Assert that error is equal to "Bad Request"
            //Assert that "requestId" is not null
        }

        [Test]
        [TestCase("BTC_USDT", "1y")]
        public async Task Given_An_Invalid_Timeframe_Then_A_200_OK_Request_Response_Is_Returned_And_Error_Message_Is_Returned(string instrumentName, string timeFrame)
        {
            // Arrange
            this.httpResponseMessage = new HttpResponseMessage();

            // Act
            var result = await RequestClient.Get(instrumentName, timeFrame);

            // Assert
            Assert.That(httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            //Assert that code is equal to 10004
            //Assert that message is equal to "Timeframe 1y is not supported."
        }

        [Test]
        [TestCase("BTC_USDT", null)]
        public async Task Given_Timeframe_Is_Not_Provided_Then_A_400_Bad_Request_Response_Is_Returned(string instrumentName, string timeFrame)
        {
            // Arrange
            this.httpResponseMessage = new HttpResponseMessage();

            // Act
            var result = await RequestClient.Get(instrumentName, timeFrame);

            // Assert
            Assert.That(httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //Assert that "timestamp" is not null
            //Assert that path is equal to "public/get-candlestick"
            //Assert that status is equal to 400
            //Assert that error is equal to "Bad Request"
            //Assert that "requestId" is not null
        }

        [Test]
        [TestCase("1BTC_USDT", "1y")]
        public async Task Given_A_Non_Existence_Instrument_Name_And_An_Invalid_Timeframe_Then_A_200_OK_Response_Is_Returned_And_Error_Message_Is_Returned(string instrumentName, string timeFrame)
        {
            // Arrange
            this.httpResponseMessage = new HttpResponseMessage();

            // Act
            var result = await RequestClient.Get(instrumentName, timeFrame);

            // Assert
            Assert.That(httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            //Assert that code is equal to 10004
            //Assert that message is equal to "Timeframe 1y is not supported."
        }

        //Test both the Prod and UAT instance
    }
    }