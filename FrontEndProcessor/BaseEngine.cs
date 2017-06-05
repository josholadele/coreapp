using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trx.Messaging;
using Trx.Messaging.Channels;
using Trx.Messaging.FlowControl;
using Trx.Messaging.Iso8583;


namespace FrontEndProcessor
{
    class BaseEngine
    {
        public static void InitializeListener(ConnectionNode connectionNode)
        {
            TcpListener tcpListener = new TcpListener(connectionNode.NodePort);
            tcpListener.LocalInterface = connectionNode.NodeIP;
            ListenerPeer listener = new ListenerPeer(connectionNode.NodeName, new TwoBytesNboHeaderChannel
                    (new Iso8583Ascii1987BinaryBitmapMessageFormatter(), connectionNode.NodeIP, connectionNode.NodePort),
                     new BasicMessagesIdentifier(11, 41), tcpListener);
            listener.Receive += new PeerReceiveEventHandler(Listener_Receive);
            tcpListener.Start();
        }

        static void Listener_Receive(object sender, ReceiveEventArgs e)
        {
            //Cast event sender as ClientPeer
            ListenerPeer sourcePeer = sender as ListenerPeer;

            SwitchNode switchNode = new SwitchNode();

            ClientPeer switchClientPeer = new ClientPeer(switchNode.NodeName, new TwoBytesNboHeaderChannel
                    (new Iso8583Ascii1987BinaryBitmapMessageFormatter(), switchNode.NodeIP, switchNode.NodePort),
                     new BasicMessagesIdentifier(11, 41));

        
            //Get the Message received
            Iso8583Message originalMessage = e.Message as Iso8583Message;


            //continue coding
            Iso8583Message responseMessage = originalMessage;
            
            
            responseMessage = Response.GetResponseMessage(originalMessage);
            sourcePeer.Send(responseMessage);
            

            sourcePeer.Listener.Start();


        }

        
    }
}
