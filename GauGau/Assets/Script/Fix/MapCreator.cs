using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public static float BLOCK_WIDTH = 1.0f; // 블록의 폭.
    public static float BLOCK_HEIGHT = 0.2f; // 블록의 높이.
    public static int BLOCK_NUM_IN_SCREEN = 52; // 화면 내에 들어가는 블록의 개수.

    BoxCreator boxCreator;

    private struct FloorBlock
    {                                // 블록에 관한 정보를 모아서 관리하는 구조체 (여러 개의 정보를 하나로 묶을 때 사용).
        public bool is_created;      // 블록이 만들어졌는가.
        public Vector3 position;     // 블록의 위치.
    };
    private FloorBlock last_block;                // 마지막에 생성한 블록.
    private PlayerControl player = null;        // 씬상의 Player를 보관.
    private BlockCreator block_creator;          // BlockCreator를 보관
    private CameraControl camera = null;
    
    void Start()
    {
        boxCreator = GameObject.Find("BoxRoot").GetComponent<BoxCreator>();

        this.camera = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        this.last_block.is_created = false;
        this.block_creator = this.gameObject.GetComponent<BlockCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 X위치를 가져온다.
        float block_generate_x = this.camera.transform.position.x;

        block_generate_x += BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN + 1) / 2.0f;
        // 마지막에 만든 블록의 위치가 문턱 값보다 작으면.
        while (this.last_block.position.x < block_generate_x)
        {
            // 블록을 만든다.
            this.create_floor_block();
        }
    }

    private void create_floor_block()
    {
        Vector3 block_position; // 이제부터 만들 블록의 위치.
        if(!this.last_block.is_created) { // last_block이 생성되지 않은 경우.
                                          // 블록의 위치를 일단 Player와 같게 한다.
            block_position = new Vector3(0,0,0);
            // 그러고 나서 블록의 X 위치를 화면 절반만큼 왼쪽으로 이동.
            block_position.x -= BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
            // 블록의 Y위치는 0으로.
            block_position.y = 0.0f;
        } 
        else
        { // last_block이 생성된 경우
          // 이번에 만들 블록의 위치를 직전에 만든 블록과 같게.
            block_position = this.last_block.position;
        }
        block_position.x += BLOCK_WIDTH;                     // 블록을 1블럭만큼 오른쪽으로 이동.
                                                             // BlockCreator 스크립트의 createBlock()메소드에 생성을 지시!.
        this.block_creator.createBlock(block_position);     // 이제까지의 코드에서 설정한 block_position을 건네준다.
        this.last_block.position = block_position;           // last_block의 위치를 이번 위치로 갱신.
        this.last_block.is_created = true;                   // 블록이 생성되었으므로 last_block의 is_created를 true로 설정.

        boxCreator.block += 1;
    }

    public bool isDelete(GameObject block_object)
    {
        bool ret = false; // 반환값.
                          // Player로부터 반 화면만큼 왼쪽에 위치, 이 위치가 사라지느냐 마느냐를 결정하는 문턱 값이 됨.
        float left_limit = this.camera.transform.position.x - BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
        // 블록의 위치가 문턱 값보다 작으면(왼쪽),
        if (block_object.transform.position.x < left_limit)
        {
            ret = true; // 반환값을 true(사라져도 좋다)로
        }
        return (ret); // 판정 결과를 돌려줌.
    }
}
