using System.Collections;
using Framework.StatePattern;
using Game.Manager;
using UI;
using UnityEngine;

namespace Game.StatePattern
{
    public class GameState : State<GameStateType, GameStateOwner> , IBordEventHandle
    {
        public GameState(Managers managers, GameStateOwner owner) : base(managers, owner)
        {
        }

        public override void OnEnter()
        {
            var window = Managers.UI.GetUIWindow<UIBordWindow>();
            var bords = CreateBords();
            window.Init(bords, this);
            window.Show(UILayerType.Content);
        }

        public void OnSelectBord(Bord bord)
        {
            bord.ChangeBordType(BordType.Blue);
        }

        Bord[] CreateBords()
        {
            var bords = new Bord[9];
            for (int i = 0; i < bords.Length; i++)
            {
                bords[i] = Bord.Create(bordId: i);
            }
            return bords;
        }
    }
}
