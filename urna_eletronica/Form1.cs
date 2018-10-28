using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; //Namespace necessária para utilizar o arquivo de som da urna

namespace urna_eletronica
{
    public partial class frmUrna : Form
    {
        string candidato; //Variável usada para armazenar o texto de cada label
        int[] candidatos = new int[14]; //Array que armazenará em cada posição o número de votos para cada candidato
        int[] numCandidato = new int[14]; //Array que armazenará em cada posição o número do candidato
        
        public frmUrna()
        {
            InitializeComponent();
        }

        private void Numeros_Click(object sender, EventArgs e)
        {            
            Button b = (Button)sender;

            if (lblNum1.Text == "") {
                lblNum1.Text = b.Text;
            }
            else if (lblNum2.Text == "") {
                lblNum2.Text = b.Text;

                candidato = lblNum1.Text + lblNum2.Text; //Variável que armazenará o texto das labels             
                
                switch (candidato)
                {
                    case "13": //Array Posição 0
                        lblNome.Text = "Fernando Haddad";
                        lblPartido.Text = "PT";
                        pctCandidato.Load("haddad.png");
                        numCandidato[0] = 13;                        
                        break;
                    case "17": //Array Posição 1
                        lblNome.Text = "Jair Bolsonaro";
                        lblPartido.Text = "PSL";
                        pctCandidato.Load("jair.jpg");
                        numCandidato[1] = 17;                        
                        break;
                    case "19": //Array Posição 2
                        lblNome.Text = "Alvaro Dias";
                        lblPartido.Text = "PODE";
                        pctCandidato.Load("alvaro.png");
                        numCandidato[2] = 19;
                        break;
                    case "51": //Array Posição 3
                        lblNome.Text = "Cabo Daciolo";
                        lblPartido.Text = "PATRI";
                        pctCandidato.Load("daciolo.png");
                        numCandidato[3] = 51;
                        break;
                    case "12": //Array Posição 4
                        lblNome.Text = "Ciro Gomes";
                        lblPartido.Text = "PDT";
                        pctCandidato.Load("ciro.png");
                        numCandidato[4] = 12;
                        break;
                    case "27": //Array Posição 5
                        lblNome.Text = "Eymael";
                        lblPartido.Text = "DC";
                        pctCandidato.Load("eymael.png");
                        numCandidato[5] = 27;
                        break;
                    case "45": //Array Posição 6
                        lblNome.Text = "Geraldo Alckmin";
                        lblPartido.Text = "PSDB";
                        pctCandidato.Load("geraldo.png");
                        numCandidato[6] = 45;
                        break;
                    case "50": //Array Posição 7
                        lblNome.Text = "Guilherme Boulos";
                        lblPartido.Text = "PSOL";
                        pctCandidato.Load("boulos.png");
                        numCandidato[7] = 50;
                        break;
                    case "15": //Array Posição 8
                        lblNome.Text = "Henrique Meirelles";
                        lblPartido.Text = "MDB";
                        pctCandidato.Load("henrique.png");
                        numCandidato[8] = 15;
                        break;
                    case "30": //Array Posição 9
                        lblNome.Text = "João Amoêdo";
                        lblPartido.Text = "NOVO";
                        pctCandidato.Load("joao.png");
                        numCandidato[9] = 30;
                        break;
                    case "54": //Array Posição 10
                        lblNome.Text = "João Goulart Filho";
                        lblPartido.Text = "PPL";
                        pctCandidato.Load("goulart.png");
                        numCandidato[10] = 54;
                        break;
                    case "18": //Array Posição 11
                        lblNome.Text = "Marina Silva";
                        lblPartido.Text = "REDE";
                        pctCandidato.Load("marina.png");
                        numCandidato[11] = 18;
                        break;
                    case "16": //Array Posição 12
                        lblNome.Text = "Vera";
                        lblPartido.Text = "PSTU";
                        pctCandidato.Load("vera.png");
                        numCandidato[12] = 16;
                        break;
                    default:
                        MessageBox.Show("Candidato Inválido","Alerta!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        lblNum1.Text = "";
                        lblNum2.Text = "";                        
                        break;
                }
            }            
        } 

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (lblNum2.Text == "") {
                MessageBox.Show("Candidato Inválido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                for (int c = 0; c < candidatos.Length; c++) {
                    if (numCandidato[c] == Convert.ToInt32(candidato))
                    {
                        candidatos[c] += 1;
                        lblVotoNulo.Text = "VOTO CONFIRMADO!";
                        lblNum1.Visible = false; lblNum2.Visible = false;
                        
                        //Som emitido após confirmação
                        SoundPlayer somUrna = new SoundPlayer(@"SomUrna.wav");
                        somUrna.Play();

                        //O evento MouseLeave do botão btnConfirma é chamado passando como parâmetro o nome da função criada (sair_MouseLeave).
                        this.btnConfirma.MouseLeave += new System.EventHandler(this.sair_MouseLeave);
                        break;
                    }
                }
            }
            //Após confirmar o voto, será aplicado os valores para os objetos abaixo
            lblNum1.Text = "";
            lblNum2.Text = "";
            lblNome.Text = "---";
            lblPartido.Text = "---";
            pctCandidato.Load("logo2.png");            
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {            
            lblNome.Text = "---";
            lblPartido.Text = "---";
            lblNum1.Text = ""; lblNum2.Text = "";
            pctCandidato.Load("logo2.png");
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {
            //Se a primeira ou a segunda label estiver vazia, uma mensagem é exibida solicitando a correção do voto
            if (lblNum1.Text != "") {
                MessageBox.Show("Corriga seu voto", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                lblVotoNulo.Text = "VOTO ANULADO!";
                lblNum1.Visible = false; lblNum2.Visible = false;
                candidatos[13] += 1; //Para cada voto nulo, será adicinado +1 à posição 13 do Array
                
                //Som emitido após confirmação
                SoundPlayer somUrna = new SoundPlayer(@"SomUrna.wav");
                somUrna.Play(); 
                
                //O evento MouseLeave do botão btnBranco é chamado passando como parâmetro o nome da função criada (sair_MouseLeave).               
                this.btnBranco.MouseLeave += new System.EventHandler(this.sair_MouseLeave);
            }                       
        }      

        private void computarVotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Assim que a opção 'Contagem de votos' for acionada, será exibida uma lista de todos os candidatos com seus respectivos votos
            MessageBox.Show(
                "Fernando Haddad: \t" + candidatos[0] + "\n\nJair Bolsonaro: \t\t" + candidatos[1] +
                "\n\nAlvaro Dias: \t\t" + candidatos[2] + "\n\nCabo Daciolo: \t\t" + candidatos[3] +
                "\n\nCiro Gomes: \t\t" + candidatos[4] + "\n\nEymael: \t\t\t" + candidatos[5] +
                "\n\nGeraldo Alckmin: \t\t" + candidatos[6] + "\n\nGuilherme Boulos: \t" + candidatos[7] +
                "\n\nHenrique Meirelles: \t" + candidatos[8] + "\n\nJoão Amoêdo: \t\t" + candidatos[9] +
                "\n\nJoão Goulart Filho: \t" + candidatos[10] + "\n\nMarina Silva: \t\t" + candidatos[11] +
                "\n\nVera: \t\t\t" + candidatos[12] + "\n\nVotos Nulos: \t\t" + candidatos[13], "Contagem de votos");
        }

        //Assim que o ponteiro do mouse sair do objeto, a função é chamada aplicando os valores para cada objeto
        private void sair_MouseLeave(object sender, EventArgs e)
        {
            lblVotoNulo.Text = "";
            lblNum1.Visible = true;
            lblNum2.Visible = true;            
        }
    }
}