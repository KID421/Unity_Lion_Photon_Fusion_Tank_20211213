using UnityEngine;
using Fusion;
using UnityEditor;

/// <summary>
/// �Z�J���a���
/// �e�ᥪ�k����
/// �����P�o�g�l�u
/// </summary>
public class PlayerControl : NetworkBehaviour
{
    #region ���
    [Header("���ʳt��"), Range(0, 100)]
    public float speed = 7.5f;
    [Header("�o�g�l�u���j"), Range(0, 1.5f)]
    public float intervalFire = 0.35f;
    [Header("�l�u����")]
    public Bullet bullet;
    [Header("�o�g��m")]
    public Transform pointFire;

    /// <summary>
    /// �s�u���ⱱ�
    /// </summary>
    private NetworkCharacterController ncc;
    #endregion

    private TickTimer delay { get; set; }

    #region �ƥ�
    private void Awake()
    {
        ncc = GetComponent<NetworkCharacterController>();
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }
    #endregion

    #region ��k
    /// <summary>
    /// Fusion �T�w��s�ƥ� ������ Unity Fixed Update
    /// </summary>
    public override void FixedUpdateNetwork()
    {
        Move();
        Fire();
    }

    public Transform tower;
    public Camera cam;

    /// <summary>
    /// ����
    /// </summary>
    private void Move()
    {
        // �p�G �� ��J���
        if (GetInput(out NetworkInputData dataInput))
        {
            // �s�u���ⱱ�.����(�t�� * ��V * �s�u�@�V�ɶ�)
            ncc.Move(speed * dataInput.direction * Runner.DeltaTime);

            Vector3 v3Mouse = dataInput.positionMouse;
            v3Mouse.z = 50;
            Vector3 positionWorldMouse = cam.ScreenToWorldPoint(v3Mouse);
            positionWorldMouse.y = tower.position.y;
            //cube.position = positionWorldMouse;

            tower.forward = positionWorldMouse - transform.position;
        }
    }

    private void Fire()
    {
        if (GetInput(out NetworkInputData dataInput))
        {
            if (delay.ExpiredOrNotRunning(Runner))
            {
                if (dataInput.inputFire)
                {
                    delay = TickTimer.CreateFromSeconds(Runner, intervalFire);

                    Runner.Spawn(
                        bullet,
                        pointFire.position,
                        tower.rotation,
                        Object.InputAuthority,
                        (runner, o) =>
                        {
                            o.GetComponent<Bullet>().Init();
                        });
                }
            }
        }
    }
    #endregion
}
