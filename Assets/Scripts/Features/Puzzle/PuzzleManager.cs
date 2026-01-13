using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Features.Puzzle
{

    public class PuzzleManager : MonoBehaviour
    {
        public void RegisterPuzzle(IPuzzle puzzle, string id) { }

        public void OnPuzzleSolved(IPuzzle puzzle)
        {
            puzzle.Solve();
        }
    }
}
