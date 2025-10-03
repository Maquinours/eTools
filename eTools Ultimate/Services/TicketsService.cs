//using eTools_Ultimate.Helpers;
//using eTools_Ultimate.Models;
//using Microsoft.Extensions.DependencyInjection;
//using Scan;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace eTools_Ultimate.Services
//{
//    public class TicketsService(SettingsService settingsService)
//    {
//        private readonly ObservableCollection<Ticket> _tickets = [];
//        public ObservableCollection<Ticket> Tickets => this._tickets;

//        private void ClearTickets()
//        {
//            foreach(Ticket ticket in Tickets)
//                ticket.Dispose();
//            Tickets.Clear();
//        }

//        public void Load()
//        {
//            ClearTickets();

//            using (Script script = new())
//            {
//                string filePath = settingsService.Settings.TicketsPropFilePath ?? settingsService.Settings.DefaultTicketsPropFilePath;
//                script.Load(filePath);

//                while (true)
//                {
//                    int dwItemId = script.GetNumber();

//                    if (script.EndOfStream) break;

//                    int dwWorldId = script.GetNumber();
//                    float vPosX = script.GetFloat();
//                    float vPosY = script.GetFloat();
//                    float vPosZ = script.GetFloat();

//                    TicketProp prop = new(dwItemId, dwWorldId, vPosX, vPosY, vPosZ);
//                    Ticket ticket = new(prop);

//                    Tickets.Add(ticket);
//                }
//            }
//        }
//    }
//}
