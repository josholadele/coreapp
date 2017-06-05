using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trx.Messaging.Iso8583;

namespace FrontEndProcessor
{

    public static class APIConnect
    {
      
        static string baseURI = "http://localhost:27558/";

        public static bool OnUs(string terminalID)
        {
            bool balance = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/Posting/OnUs/?terminalID=" + terminalID).Result;
                if (response.IsSuccessStatusCode)
                {
                    balance = bool.Parse(response.Content.ReadAsStringAsync().Result);
                }
            }
            return balance;
        }
        public static string GetAccountBalance(string accountNumber)
        {
            string balance = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/CustomerAccount/GetAccountBalance/?accountNumber=" + accountNumber).Result;
                if (response.IsSuccessStatusCode)
                {
                    balance = response.Content.ReadAsStringAsync().Result;
                }
            }
            return balance;
        }
        public static void OnUsPostTransaction(string accountNumber, double txnAmount, string ODE)
        {
            string theResponse = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/Posting/OnUsPostTransaction?accountNumber=" + accountNumber + "&txnAmount=" + txnAmount + "&ODE=" + ODE).Result;
                if (response.IsSuccessStatusCode)
                {
                    theResponse = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        public static void RemoteOnUsPost(string accountNumber,double txnAmount, string ODE)
        {
            string theResponse = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/Posting/RemoteOnUsPost?accountNumber=" + accountNumber + "&txnAmount=" + txnAmount + "&ODE=" + ODE).Result;
                if (response.IsSuccessStatusCode)
                {
                    theResponse = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        public static void PostFee(string accountNumber, double txnFee, string ODE)
        {
            string theResponse = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/Posting/PostFee?accountNumber=" + accountNumber + "&txnFee=" + txnFee + "&ODE=" + ODE).Result;
                if (response.IsSuccessStatusCode)
                {
                    theResponse = response.Content.ReadAsStringAsync().Result;
                }
            }
        }





        
        public static void CreditPaymentPost(string creditAccNumber, double txnAmnt,string ODE)
        {
            string theResponse = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/Posting/CreditPaymentPost?accountNumber=" + creditAccNumber + "&txnAmount=" + txnAmnt + "&ODE=" + ODE).Result;
                if (response.IsSuccessStatusCode)
                {
                    theResponse = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        public static void DebitPaymentPost(string debitAccNumber, double txnAmnt, string ODE)
        {
            string theResponse = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/Posting/DebitPaymentPost?accountNumber=" + debitAccNumber + "&txnAmount=" + txnAmnt + "&ODE=" + ODE).Result;
                if (response.IsSuccessStatusCode)
                {
                    theResponse = response.Content.ReadAsStringAsync().Result;
                }
            }
        }


        public static bool TransactionExists(string ODE)
        {
            string postingID = "";
            string theResponse = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/Reversal/CheckTransaction?ODE=" + ODE).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                    //theResponse = response.Content.ReadAsStringAsync().Result;
                    //postingID = theResponse;

                }
            }
            return false;
        }
        public static bool PostReversal(string ode)
        {
            string theResponse = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                    client.GetAsync("api/Reversal/PostReversal?ODE="+ode).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                    theResponse = response.Content.ReadAsStringAsync().Result;
                }
                return false;
            }
        }
    }
}
