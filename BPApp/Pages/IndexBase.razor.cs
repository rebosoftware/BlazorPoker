using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPData.Lists;
using BPData.Models;
using BPData.Services;
using Microsoft.AspNetCore.Components;

namespace BPApp.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] DeckService DeckSvc { get; set; }
        [Inject] EvalService EvalSvc { get; set; }
        [Inject] GameService GameSvc { get; set; }

        protected Player player = null;
        protected Player dealer = null;
        protected Player me = null;
        protected bool AlwaysShow { get; set; }

        protected bool DisableDiscard { get; set; }
        protected bool DisableDraw { get; set; }


        //protected string TableImage = "table614_352.png";
        //protected string TableImage = "table767_440.png";
        protected string TableImage = "table500_492.png";

        protected string TableWidth = "492px";
        protected string TableHeight = "500px";

        protected string CardWidth = "50px";    //"50px";
        protected string CardHeight = "85px";   //"85px";

        protected string DiscardWidth = "50px"; 
        protected string DiscardHeight = "90px"; 

        /// <summary>
        /// override of ComponentBase::OnInitialized
        /// </summary>
        protected override void OnInitialized()
        {
            DisableDiscard = true;
            DisableDraw = true;

            AlwaysShow = false;

            //initialize the game
            GameSvc.Init();
                        
            //create the dealer
            dealer = new Player();
            dealer.Name = "Dealer";
            dealer.Type = BPData.BPConstants.Dealer;
            dealer.Human = false;//auto discard
            dealer.Seat = 1;
            GameSvc.AddPlayer(dealer);

            //create the player
            player = new Player();
            player.Name = "Player";
            player.Type = BPData.BPConstants.Player;
            player.Human = true;//player discards
            player.Seat = 2;
            GameSvc.AddPlayer(player);

            me = player;

            NewGame();
        }

        protected void Discard()
        {
            DisableDiscard = true;
            GameSvc.DiscardPlayersCards();
            DisableDraw = false;
        }

        protected void Draw()
        {
            DisableDraw = true;
            DisableDiscard = true;
            GameSvc.DealPlayersDraw();
            GameSvc.ChooseWinners();
        }

        protected void NewGame()
        {
            //start the game, state will be GS_WaitForDiscard
            GameSvc.StartGame();
            DisableDraw = true;
            DisableDiscard = false;
        }
    }
}
