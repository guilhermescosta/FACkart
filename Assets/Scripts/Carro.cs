using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    public WheelCollider[] ColisoresRodas;
    public WheelEffects[] efeitoRoda;
    public GameObject Volante;
    private bool re;
    private AudioSource m_AudioSource;
    public Vector3 centroMassa;
    public Vector3 tamanhoRoda;
    private float VirarRodas;
    private float lado;
    private float frente;
    private bool freioMao;
    public GameObject FormatoRoda;
    public float limiteDeslisar;
    public float rotacaoMaxima;
    public float potencia;
    private Rigidbody rbCarro;
    private float velocidadeAtual { get { return rbCarro.velocity.magnitude * 2.23693629f; } }
    public float velocidadePassar { get; private set; }
    public float potenciaFreio;
    public float velMaxima;
    private WheelFrictionCurve ff;
    private WheelFrictionCurve fs;
    public float Revs { get; private set; }
    private int cc;
    private bool trocandomarchas;
    private float marchas;
    public int qtdMarchas;
    private bool PlayingAudio;
    
    public float rotacao { get; private set; }
    public void mover(float lado, float frente, bool freioMao) {
        this.freioMao = freioMao;
        this.frente = frente;
        this.lado = lado;
    }
    public void desvira() {
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, this.gameObject.transform.eulerAngles.y, 0);
        rbCarro.AddForce(transform.up * -rbCarro.mass*750);
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (WheelCollider wheel in ColisoresRodas) {
            if (FormatoRoda != null)
            {
                var ws = Instantiate(FormatoRoda);
                ws.transform.parent = wheel.transform;
                ws.transform.localScale = tamanhoRoda;
            }
        }
        
        cc = 0;
        potenciaFreio *= -1;
        rbCarro = this.gameObject.GetComponent<Rigidbody>();
        //potencia *= 100;
        
        ff = ColisoresRodas[0].forwardFriction;
        fs = ColisoresRodas[0].sidewaysFriction;
        Revs = 950;
        marchas = 1;
        trocandomarchas = false;
        re = false;
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void PlayAudio()
    {
        m_AudioSource.Play();
        PlayingAudio = true;
    }
    public void StopAudio()
    {
        m_AudioSource.Stop();
        PlayingAudio = false;
    }
    void Update()
    {   
        ColisoresRodas[0].attachedRigidbody.centerOfMass = centroMassa;
        velocidadePassar = velocidadeAtual;
        foreach (WheelCollider wheel in ColisoresRodas)
        {
            Quaternion q;
            Vector3 p;
            wheel.GetWorldPose(out p, out q);
            Transform shapeTransform = wheel.transform.GetChild(0);
            shapeTransform.position = p;
            shapeTransform.rotation = q;
            WheelHit wheelHit;
            wheel.GetGroundHit(out wheelHit);
            if (Mathf.Abs(wheelHit.forwardSlip) >= limiteDeslisar || Mathf.Abs(wheelHit.sidewaysSlip) >= limiteDeslisar){
                efeitoRoda[cc].StartSkidTrail();
                efeitoRoda[cc].EmitTyreSmoke();
                if (this.PlayingAudio==false)
                {
                    this.PlayAudio();
                }
                cc++;
                continue;
            }
            if (this.PlayingAudio){
                this.StopAudio();
            }
            efeitoRoda[cc].EndSkidTrail();
            cc++;
        }
        cc = 0;

        if (freioMao == true)
        {
            // frieo de mão puxado
            
            //ColisoresRodas[2].motorTorque = 0;
            //ColisoresRodas[3].motorTorque = 0;
            ColisoresRodas[2].brakeTorque = 2000000;
            ColisoresRodas[3].brakeTorque = 2000000;
            if (Revs > 950 && frente==0)
            {
                Revs -= potencia;
            }
        }
        
        if (frente > 0 && freioMao==false)
        {
            // andando para frente
            re=false;
            ColisoresRodas[2].brakeTorque = 0;
            ColisoresRodas[3].brakeTorque = 0;
            ColisoresRodas[0].brakeTorque = 0;
            ColisoresRodas[1].brakeTorque = 0;
            ColisoresRodas[2].motorTorque = frente * (potencia / 2);
            ColisoresRodas[3].motorTorque = frente * (potencia / 2);
            Revs += potencia / 4;
            if (re == true && Revs > 950) {
                Revs += potenciaFreio;
            }
        }
        else if (frente < 0 && freioMao==false)
        {
            if (velocidadeAtual > 1 && Vector3.Angle(transform.forward, rbCarro.velocity) < 50f)
            {
                //freiando
                re=false;
                ColisoresRodas[2].motorTorque = 0;
                ColisoresRodas[3].motorTorque = 0;
                ColisoresRodas[0].brakeTorque = frente * potenciaFreio;
                ColisoresRodas[1].brakeTorque = frente * potenciaFreio;
                ColisoresRodas[2].brakeTorque = frente * potenciaFreio;
                ColisoresRodas[3].brakeTorque = frente * potenciaFreio;
                if (Revs > 950){
                    Revs += potenciaFreio;
                }
            }
            else if (freioMao==false){
                // dando re
                marchas = 1;
                re = true;
                ColisoresRodas[2].brakeTorque = 0;
                ColisoresRodas[3].brakeTorque = 0;
                ColisoresRodas[0].brakeTorque = 0;
                ColisoresRodas[1].brakeTorque = 0;
                if (velocidadeAtual < velMaxima / 5){
                    ColisoresRodas[2].motorTorque = frente * (potencia / 2);
                    ColisoresRodas[3].motorTorque = frente * (potencia / 2);
                    Revs += potencia*2;
                }else {
                    ColisoresRodas[2].motorTorque = 0;
                    ColisoresRodas[3].motorTorque = 0;
                }
            }
        }
        else if (frente == 0 && freioMao==false)
        {
            // parado
            re=false;
            ColisoresRodas[2].motorTorque = 0;
            ColisoresRodas[3].motorTorque = 0;
            ColisoresRodas[0].brakeTorque = 10;
            ColisoresRodas[1].brakeTorque = 10;
            ColisoresRodas[2].brakeTorque = 10;
            ColisoresRodas[3].brakeTorque = 10;
            if (Revs > 950){
                Revs -= potencia;
            }
        }

        // controla para que lado o carro está virando
        if (lado > 0 && ColisoresRodas[0].steerAngle <= 25) {
            ColisoresRodas[0].steerAngle += 2.5f;
            ColisoresRodas[1].steerAngle += 2.5f;
            Volante.transform.eulerAngles = new Vector3(Volante.transform.eulerAngles.x, Volante.transform.eulerAngles.y, Volante.transform.eulerAngles.z - 5);
        }
        if (lado < 0 && ColisoresRodas[0].steerAngle >= -25)
        {
            ColisoresRodas[0].steerAngle -= 2.5f;
            ColisoresRodas[1].steerAngle -= 2.5f;
            Volante.transform.eulerAngles = new Vector3(Volante.transform.eulerAngles.x, Volante.transform.eulerAngles.y, Volante.transform.eulerAngles.z + 5);
        }
        if (lado == 0 && ColisoresRodas[0].steerAngle > 0) {
            ColisoresRodas[1].steerAngle --;
            ColisoresRodas[0].steerAngle--;
            Volante.transform.eulerAngles = new Vector3(Volante.transform.eulerAngles.x, Volante.transform.eulerAngles.y, Volante.transform.eulerAngles.z + 2.5f);
        }
        if (lado == 0 && ColisoresRodas[0].steerAngle < 0)
        {
            ColisoresRodas[1].steerAngle++;
            ColisoresRodas[0].steerAngle++;
            Volante.transform.eulerAngles = new Vector3(Volante.transform.eulerAngles.x, Volante.transform.eulerAngles.y, Volante.transform.eulerAngles.z - 2.5f);
        }

        // controla o quao liso sao os pneus
        if (velocidadeAtual < velMaxima/2 && ff.stiffness != 4) {
            
            ff.stiffness = 4;
            ColisoresRodas[2].forwardFriction = ff;
            ColisoresRodas[3].forwardFriction = ff;
        }
        if (velocidadeAtual >= velMaxima/2 && ff.stiffness != 3)
        {
            ff.stiffness = 3;
            ColisoresRodas[2].forwardFriction = ff;
            ColisoresRodas[3].forwardFriction = ff;
        }
        
        if (velocidadeAtual < (velMaxima / 3) && fs.stiffness != 1)
        {

            fs.stiffness = 1;
            ColisoresRodas[0].sidewaysFriction = fs;
            ColisoresRodas[1].sidewaysFriction = fs;
        }
        if (velocidadeAtual < ((velMaxima / 3) * 2) && velocidadeAtual >= (velMaxima / 3) && fs.stiffness != 0.75f)
        {
            fs.stiffness = 0.75f;
            ColisoresRodas[0].sidewaysFriction = fs;
            ColisoresRodas[1].sidewaysFriction = fs;
        }
        if (velocidadeAtual >= ((velMaxima / 3) * 2) && fs.stiffness != 0.5f)
        {
            fs.stiffness = 0.5f;
            ColisoresRodas[0].sidewaysFriction = fs;
            ColisoresRodas[1].sidewaysFriction = fs;
        }

        // Controla o som do carro, as rotações do motor nao inteferem na fisica dele
        if (Revs >= rotacaoMaxima &&  re == false && marchas < qtdMarchas) {
            trocandomarchas = true;
            marchas++;
        }
        if (Revs >= rotacaoMaxima && re == false && marchas == qtdMarchas)
        {
            Revs -= rotacaoMaxima/20;
        }
        if (Revs >= rotacaoMaxima && re == true) {
            Revs = rotacaoMaxima;
        }
        if (trocandomarchas == true) {
            Revs -= 500;
        }
        if (Revs < rotacaoMaxima / 2 && marchas > 1) {
            Revs += rotacaoMaxima / 5;
            marchas--;
        }
        if (Revs <= (rotacaoMaxima / 2) + (rotacaoMaxima / 10)) {
            trocandomarchas = false;
            //Revs = (rotacaoMaxima / 2) + (rotacaoMaxima / 10);
        }
        rotacao = Revs / rotacaoMaxima;
        
        //Debug.Log("velocidade: "+velocidadeAtual.ToString("f0")+"\n Revs: "+ Revs.ToString("f0"));
    }
}
