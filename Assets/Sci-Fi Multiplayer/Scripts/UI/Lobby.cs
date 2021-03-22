using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battlecars.Networking;

namespace Battlecars.UI
{
    public class Lobby : MonoBehaviour
    {

        private List<LobbyPlayerSlot> leftTeamSlots = new List<LobbyPlayerSlot>();
        private List<LobbyPlayerSlot> rightTeamSlots = new List<LobbyPlayerSlot>();

        [SerializeField] private GameObject leftTeamHolder;
        [SerializeField] private GameObject rightTeamHolder;

        private bool assigningToleft = true;

        public void OnPlayerConnected(BattlecarsPlayerNet _player)
        {
            bool assigned = false;

            List<LobbyPlayerSlot> slots = assigningToleft ? leftTeamSlots : rightTeamSlots;

            
                leftTeamSlots.ForEach(slot => 
                {
                    if (assigned)
                    {
                        return;
                    }
                    else if (!slot.IsTaken)
                    {
                        ///if we havent already assigned the player to a slot and this slot
                        ///hasnt been taken, assign the player to this slot and flag
                        ///as slot been assigned
                        slot.AssignPlayer(_player);
                        assigned = true;
                    }
                });
            
            

            assigningToleft = !assigningToleft;
        }

        // Start is called before the first frame update
        void Start()
        {
            //Fill the two lists with there slots
            leftTeamSlots.AddRange(leftTeamHolder.GetComponentsInChildren<LobbyPlayerSlot>());
            rightTeamSlots.AddRange(rightTeamHolder.GetComponentsInChildren<LobbyPlayerSlot>());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
