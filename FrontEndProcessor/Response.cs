using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trx.Messaging.Iso8583;

namespace FrontEndProcessor
{
    public class Response:Check
    {
        public static Iso8583Message GetResponseMessage(Iso8583Message originalMessage)
        {
            string txnTypeCode = originalMessage.Fields[3].Value.ToString().Substring(0, 2);

            string txnChannelCode = originalMessage.Fields[41].Value.ToString().Substring(0, 1);

            string txnAccountNumber = originalMessage.Fields[102].Value.ToString();

            string creditAccNumber = originalMessage.Fields[103].Value.ToString();

            string txnAmnt = originalMessage.Fields[4].Value.ToString();
            string txnFee = originalMessage.Fields[28].Value.ToString();
            
            Transaction transaction = new Transaction();
            List<string> allowedTransactionList = transaction.AllowedTransactions;


            Iso8583Message responseMessage = originalMessage;

            string expiryDateString = originalMessage.Fields[14].Value.ToString();
            int expiryDate = int.Parse(expiryDateString);

            string cardPan = originalMessage.Fields[2].Value.ToString();

            string terminalID = originalMessage.Fields[41].Value.ToString();

            string ODE = originalMessage.Fields[90].Value.ToString();




            if (originalMessage.MessageTypeIdentifier != 421)
            {
                switch (txnTypeCode)
                {
                    case "31":
                        string balance = APIConnect.GetAccountBalance(txnAccountNumber);
                        responseMessage.Fields.Add(54, balance);
                        AddResponseCode(responseMessage, "00");
                        responseMessage.MessageTypeIdentifier = 210;
                        return responseMessage;

                    case "01":

                        double accBalance = double.Parse(APIConnect.GetAccountBalance(txnAccountNumber));
                        double txnAmount = double.Parse(txnAmnt)/100;
                        double txnTotal = txnAmount + double.Parse(txnFee);

                        if (APIConnect.OnUs(terminalID) && txnAmount <= accBalance)
                        {
                            APIConnect.PostFee(txnAccountNumber, double.Parse(txnFee),ODE);
                            APIConnect.OnUsPostTransaction(txnAccountNumber, txnAmount,ODE);
                            AddResponseCode(responseMessage, "00");
                        }

                        else if (!APIConnect.OnUs(terminalID) && txnTotal <= accBalance)
                        {
                            APIConnect.PostFee(txnAccountNumber, double.Parse(txnFee),ODE);
                            APIConnect.RemoteOnUsPost(txnAccountNumber, txnAmount,ODE);
                            AddResponseCode(responseMessage, "00");
                        }

                        else
                        {
                            AddResponseCode(responseMessage, "51");
                        }

                        responseMessage.MessageTypeIdentifier = 210;
                        return responseMessage;

                    case "50":

                        bool contains102 = responseMessage.Fields.Contains(102);
                        bool contains103 = responseMessage.Fields.Contains(103);

                        if (contains102 && contains103)
                        {
                            double theFee = double.Parse(txnFee);
                            txnAmount = double.Parse(txnAmnt) / 100;
                            APIConnect.DebitPaymentPost(txnAccountNumber, txnAmount, ODE);
                            APIConnect.CreditPaymentPost(creditAccNumber, txnAmount, ODE);
                            AddResponseCode(responseMessage, "00");
                            responseMessage.MessageTypeIdentifier = 210;
                        }
                        else if (contains102)
                        {
                            double theFee = double.Parse(txnFee);
                            txnAmount = double.Parse(txnAmnt) / 100;
                            //APIConnect.DebitPaymentPost(creditAccNumber, txnAmount, ODE);
                            APIConnect.DebitPaymentPost(txnAccountNumber, txnAmount, ODE);
                            AddResponseCode(responseMessage, "00");
                            responseMessage.MessageTypeIdentifier = 210;
                        }
                        else
                        {
                            txnAmount = double.Parse(txnAmnt) / 100;
                            APIConnect.CreditPaymentPost(creditAccNumber, txnAmount,ODE);
                            AddResponseCode(responseMessage, "00");
                            responseMessage.MessageTypeIdentifier = 210;
                        }
                        return responseMessage;

                    default:

                        AddResponseCode(responseMessage, "12");
                        responseMessage.MessageTypeIdentifier = 210;
                        return responseMessage;
                }
            }
            else
            {
                //string postingID = APIConnect.TransactionExists(ODE);
                if (APIConnect.TransactionExists(ODE))
                {
                    if (APIConnect.PostReversal(ODE))
                    {
                        AddResponseCode(responseMessage, "00");
                    }
                    else
                    {
                        AddResponseCode(responseMessage, "25");
                    }
                }
                else
                {
                    AddResponseCode(responseMessage, "21");
                }
                responseMessage.MessageTypeIdentifier = 410;
                return responseMessage;
            }
        }

    
        static Iso8583Message AddResponseCode(Iso8583Message isoMessage, string code)
        {
            isoMessage.Fields.Add(39, code);
            Iso8583Message responseMsg = isoMessage;
            return responseMsg;
        }
   
    }
}
