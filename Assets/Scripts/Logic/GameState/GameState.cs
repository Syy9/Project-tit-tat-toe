using System.Collections;
using Framework.StatePattern;
using Game.Manager;
using UI;
using UnityEngine;

namespace Game.StatePattern
{
    public class GameState : State<GameStateType, GameStateOwner> , IBordEventHandle
    {
        PlayerType turnPlayer = PlayerType.Player1;
        GameCalclator calclator;
        Bord selectBord = null;
        public GameState(Managers managers, GameStateOwner owner) : base(managers, owner)
        {
        }

        public override void OnEnter()
        {
            var window = Managers.UI.GetUIWindow<UIBordWindow>();
            var bords = CreateBords();
            window.Init(bords, this);
            window.UpdateTurnPlayerName(turnPlayer);
            window.Show(UILayerType.Content);

            calclator = new GameCalclator(bords);
            Managers.Coroutine.Call(GameProcess());
        }

        IEnumerator GameProcess()
        {
            Result result = Result.CreateNotDone();
            do {
                yield return new WaitUntil(() => selectBord != null);
                var bord = selectBord;
                selectBord = null;
                if (bord.HasOwner())
                {
                    continue;
                }

                bord.ChangeOwner(turnPlayer);
                bord.ChangeBordType(BordType.Checked);

                result = calclator.CalcResult();
                if (!result.IsDone)
                {
                    turnPlayer = turnPlayer.GetNextPlayer();
                    var window = Managers.UI.GetUIWindow<UIBordWindow>();
                    window.UpdateTurnPlayerName(turnPlayer);
                }
            } while(!result.IsDone);

            Owner.ChangeState(GameStateType.Result, result.Winner);
        }

        public void OnSelectBord(Bord bord)
        {
            selectBord = bord;
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
