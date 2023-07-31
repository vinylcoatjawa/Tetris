
using UnityEngine;

public class testing : MonoBehaviour
{

    public VoidListener OnTick;

    public struct Block{
            Vector2Int[] Pieces;
            Vector2Int Anchor;
            public Block(Vector2Int[] pieces, Vector2Int anchor){
                this.Pieces = pieces;
                this.Anchor = anchor;
            }
            public Vector2Int[] GetPieces(){
                return Pieces;
            }
            public Vector2Int GetAnchor(){
                return Anchor;
            }
    };
    public static Vector2Int[] _sBlock = new Vector2Int[]{
        new Vector2Int(-1,0),
        new Vector2Int(0,0),
        new Vector2Int(0,1),
        new Vector2Int(1,1),

    };
    Block Shift(Block block, Vector2Int shift){
        for (int i = 0; i < block.GetPieces().Length; i++)
        {
            block.GetPieces()[i] += shift;
        }
        Vector2Int newAnchor = block.GetAnchor() + shift;
        return new Block(block.GetPieces(), newAnchor);

    }
    Block current = new Block (_sBlock, new Vector2Int(0,0));
    Block current_2 = new Block (_sBlock, new Vector2Int(0,0));
    Vector2Int _shift = new Vector2Int(4,5);
    Grid<float> _grid;

    void Start()
    {
        _grid = new Grid<float>(12, 20, 10f, Vector3.zero, (Grid<float> grid, int x, int z) => 0f, true);
        Block shifted = Shift(current, new Vector2Int(3,3));
        Block rotated = RoatateLeft(shifted, new Vector2Int(5,5));
        //_grid.SetGridObject(2, 19, 1);
        //Block current = new Block (_sBlock, new Vector2Int(0,0));
        /*foreach (var item in current.GetPieces())
        {
            _grid.SetGridObject(item.x + _shift.x, item.y + _shift.y, 1);
        }*/
        foreach (var item in rotated.GetPieces())
        {
            _grid.SetGridObject(item.x, item.y, 1);
        }


    }

    public Block RoatateLeft(Block block, Vector2Int shift){
       Vector2Int[] result = new Vector2Int[4];
       int i = 0;
       foreach (var item in block.GetPieces())
       {
            Vector2Int normalized = item - shift;
            //Vector2Int res = new Vector2Int( item.x,-item.y );
            result[i] = new Vector2Int(-normalized.y + shift.x, normalized.x + shift.y);
            Debug.Log($" the {i}th is {result[i]}");
            i++;
       }

       return new Block(result, block.GetAnchor());
       
        
    }

  


    void Update()
    {
        
    }
}
