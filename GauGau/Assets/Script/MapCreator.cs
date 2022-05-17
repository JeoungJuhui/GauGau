using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public static float BLOCK_WIDTH = 1.0f; // ����� ��.
    public static float BLOCK_HEIGHT = 0.2f; // ����� ����.
    public static int BLOCK_NUM_IN_SCREEN = 52; // ȭ�� ���� ���� ����� ����.

    BoxCreator boxCreator;

    private struct FloorBlock
    {                                // ��Ͽ� ���� ������ ��Ƽ� �����ϴ� ����ü (���� ���� ������ �ϳ��� ���� �� ���).
        public bool is_created;      // ����� ��������°�.
        public Vector3 position;     // ����� ��ġ.
    };
    private FloorBlock last_block;                // �������� ������ ���.
    private PlayerControl player = null;        // ������ Player�� ����.
    private BlockCreator block_creator;          // BlockCreator�� ����
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
        // �÷��̾��� X��ġ�� �����´�.
        float block_generate_x = this.camera.transform.position.x;

        block_generate_x += BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN + 1) / 2.0f;
        // �������� ���� ����� ��ġ�� ���� ������ ������.
        while (this.last_block.position.x < block_generate_x)
        {
            // ����� �����.
            this.create_floor_block();
        }
    }

    private void create_floor_block()
    {
        Vector3 block_position; // �������� ���� ����� ��ġ.
        if(!this.last_block.is_created) { // last_block�� �������� ���� ���.
                                          // ����� ��ġ�� �ϴ� Player�� ���� �Ѵ�.
            block_position = new Vector3(0,0,0);
            // �׷��� ���� ����� X ��ġ�� ȭ�� ���ݸ�ŭ �������� �̵�.
            block_position.x -= BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
            // ����� Y��ġ�� 0����.
            block_position.y = 0.0f;
        } 
        else
        { // last_block�� ������ ���
          // �̹��� ���� ����� ��ġ�� ������ ���� ��ϰ� ����.
            block_position = this.last_block.position;
        }
        block_position.x += BLOCK_WIDTH;                     // ����� 1����ŭ ���������� �̵�.
                                                             // BlockCreator ��ũ��Ʈ�� createBlock()�޼ҵ忡 ������ ����!.
        this.block_creator.createBlock(block_position);     // ���������� �ڵ忡�� ������ block_position�� �ǳ��ش�.
        this.last_block.position = block_position;           // last_block�� ��ġ�� �̹� ��ġ�� ����.
        this.last_block.is_created = true;                   // ����� �����Ǿ����Ƿ� last_block�� is_created�� true�� ����.

        boxCreator.block += 1;
    }

    public bool isDelete(GameObject block_object)
    {
        bool ret = false; // ��ȯ��.
                          // Player�κ��� �� ȭ�鸸ŭ ���ʿ� ��ġ, �� ��ġ�� ��������� �����ĸ� �����ϴ� ���� ���� ��.
        float left_limit = this.camera.transform.position.x - BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
        // ����� ��ġ�� ���� ������ ������(����),
        if (block_object.transform.position.x < left_limit)
        {
            ret = true; // ��ȯ���� true(������� ����)��
        }
        return (ret); // ���� ����� ������.
    }
}
