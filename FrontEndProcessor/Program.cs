using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Logic;

namespace FrontEndProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //string time = DateTime.Now.ToShortTimeString();
            //string date = DateTime.Now.ToShortDateString();
            //GLPostingLogic logic = new GLPostingLogic();
            //logic.GetById(2114);
            //GLPostingLogic glPostingLogic = new GLPostingLogic();
            //List<GLPosting> glPostings = glPostingLogic.GetPostingsByODE("000000000000000000000020055848320160420012");
            //glPostingLogic.UpdateIsReversible(2115);
            Start();
            Console.ReadKey();
        }

        public static void Start()
        {
            ConnectionNode connectionNode = new ConnectionNode();
            BaseEngine.InitializeListener(connectionNode);
            
            Console.WriteLine("Listening......");
         
        }
        }
    }

