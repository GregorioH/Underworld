using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public CharacterController CharCont;
    public Camera Camara;
    // public Animator animator;

    private Estad�sticas est;

    public GameObject EspadaInicial;
    public GameObject ArcoInicial;

    public float gravedad = -9.81f;
    public Vector3 direccion;

    public Transform checkPiso;
    public GameObject Manos;
    public float distanciaPiso = 0.4f;
    public LayerMask capaPiso;
    public LayerMask capaUI;
    bool tocaPiso;

    // public GameObject menuPausa;

    // Tu codigo es una porqueria  salu2

    private void Start()
    {
        est = GameObject.Find("Game Manager").GetComponent<Estad�sticas>();

        switch (PlayerPrefs.GetString("Arma"))
        {
            case "Espada":
                GameObject Espada = Instantiate(EspadaInicial, Manos.transform.GetChild(1).position, EspadaInicial.transform.rotation);
                Espada.transform.parent = Manos.transform.GetChild(1);
                break;
            case "Arco":
                GameObject Arco = Instantiate(ArcoInicial, Manos.transform.GetChild(1).position, ArcoInicial.transform.rotation);
                Arco.transform.parent = Manos.transform.GetChild(1);
                break;
            default:
                break;
        }

    }

    void Update()
    {
        // Saber si toca el piso o no

        tocaPiso = Physics.CheckSphere(checkPiso.position, distanciaPiso, capaPiso);

        if (tocaPiso && direccion.y < 0)
        {
            direccion.y = -2f;
        }

        // Movimiento

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = (transform.right * x + transform.forward * z);
        CharCont.Move(Vector3.ClampMagnitude(mover, 1) * est.velocidadJ * Time.deltaTime);

        direccion.y += gravedad * Time.deltaTime;
        CharCont.Move(direccion * Time.deltaTime);

        // Guardar o sacar el arma

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Manos.activeSelf == true)
            {
                Manos.SetActive(false);
            }
            else
            {
                Manos.SetActive(true);
            }
        }

        /*

        // Animaciones

        if ((x != 0 || z != 0) && est.velocidadJ == 3 && animator.GetInteger("SUPERESTADO") != 3)
        {
            animator.SetInteger("SUPERESTADO", 1);
        }
        else if (x == 0 && z == 0 && animator.GetInteger("SUPERESTADO") != 3)
        {
            animator.SetInteger("SUPERESTADO", 0);
        }

        */


        // Limitar estad�sticas

        if (est.vidaJ <= 0)
        {
            est.vidaJ = 0;
        }

        // Raycast (Disparo)

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(Camara.gameObject.transform.position, Camara.gameObject.transform.TransformDirection(Vector3.forward) * est.rangoRaycastJ, Color.green);

            if (Physics.Raycast(Camara.gameObject.transform.position, Camara.gameObject.transform.TransformDirection(Vector3.forward), out hit, est.rangoRaycastJ, capaUI))
            {
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                Debug.Log("Funciona");
            }
        }

        /*

        segundosCooldownDisparo += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && segundosCooldownDisparo >= est.cooldownAtaqueJ && est.municionJ > 0 && puedeRecargar == true)
        {
            segundosCooldownDisparo = 0;

            est.municionJ -= 1;

            animator.SetInteger("SUPERESTADO", 3);

            CharCont.enabled = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            if (Physics.Raycast(Camara.gameObject.transform.position, Camara.gameObject.transform.TransformDirection(Vector3.forward), out hit, est.rangoJ, capaEnemigos))
            {
                Debug.DrawRay(Camara.gameObject.transform.position, Camara.gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Golpeo enemigo");
            }
            else
            {
                Debug.DrawRay(Camara.gameObject.transform.position, Camara.gameObject.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Golpeo otra cosa");
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            CharCont.enabled = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            animator.SetInteger("SUPERESTADO", 0);
        }

        // Pausar el juego

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPausaDerrotaVictoria();

            menuPausa.transform.GetChild(0).GetComponent<Text>().text = "Pausa";
        }

        

        // Perder

        if (est.vidaJ <= 0)
        {
            MenuPausaDerrotaVictoria();

            menuPausa.transform.GetChild(0).GetComponent<Text>().text = "Te han matado...";

            eliminarDespausar();
        }
        else if (est.tiempoRestante <= 0)
        {
            MenuPausaDerrotaVictoria();

            menuPausa.transform.GetChild(0).GetComponent<Text>().text = "Se acab� el tiempo";

            eliminarDespausar();
        }

        // Ganar

        if (est.sobrevivientesRestantes == 0)
        {
            MenuPausaDerrotaVictoria();

            menuPausa.transform.GetChild(0).GetComponent<Text>().text = "�Has ganado!";

            eliminarDespausar();
        }
    }

    // Menu al pausar o perder

    void MenuPausaDerrotaVictoria()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        menuPausa.SetActive(true);

        Time.timeScale = 0;

        this.enabled = false;
    }

    // Eliminar el boton de despausar para los men�s de derrota y victoria

    void eliminarDespausar()
    {
        menuPausa.transform.GetChild(1).gameObject.SetActive(false);
        menuPausa.transform.GetChild(2).GetComponent<RectTransform>().position = new Vector2(960, 540);
        menuPausa.transform.GetChild(3).GetComponent<RectTransform>().position = new Vector2(960, 360);
    }

    */

        // Comentario de prueba
    }
}