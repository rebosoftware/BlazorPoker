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

        protected string TableImage = "http://localhost:63988/table.png";
        
        /// <summary>
        /// override of ComponentBase::OnInitialized
        /// </summary>
        protected override void OnInitialized()
        {
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
            GameSvc.DiscardPlayersCards();
        }

        protected void Draw()
        {
            //List<Card> cards = player.Hand;
            //List<Card> h = GameSvc.GetPlayerHand(2);
           
            GameSvc.DealPlayersDraw();

            GameSvc.ChooseWinners();
        }

        protected void NewGame()
        {
            //start the game, state will be GS_WaitForDiscard
            GameSvc.StartGame();
        }
    }
}
