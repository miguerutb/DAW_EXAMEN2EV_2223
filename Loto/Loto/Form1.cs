using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotoClassNS;

namespace ExamenLoto
{
    public partial class Examen2EVMTB2223 : Form
    {
        public const int MAX_NUMEROS = 6;

        public MTB2223 miLoto, miGanadora;
        private TextBox[] combinacion = new TextBox[MAX_NUMEROS]; // Estos arrays se usan para recorrer de manera más sencilla los controles
        private TextBox[] ganadora = new TextBox[MAX_NUMEROS];
        public Examen2EVMTB2223()
        {
            InitializeComponent();
            InicializarValores();
            miGanadora = new MTB2223(); // generamos la combinación ganadora
            for (int i = 0; i < MAX_NUMEROS; i++)
                ganadora[i].Text = Convert.ToString(miGanadora.Nums[i]);

        }

        private void InicializarValores()
        {
            combinacion[0] = txtNumero1;
            combinacion[1] = txtNumero2;
            combinacion[2] = txtNumero3;
            combinacion[3] = txtNumero4;
            combinacion[4] = txtNumero5;
            combinacion[5] = txtNumero6;

            ganadora[0] = txtGanadora1;
            ganadora[1] = txtGanadora2;
            ganadora[2] = txtGanadora3;
            ganadora[3] = txtGanadora4;
            ganadora[4] = txtGanadora5;
            ganadora[5] = txtGanadora6;
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            miLoto = new MTB2223(); // usamos constructor vacío, se genera combinación aleatoria
            for ( int i=0; i< MAX_NUMEROS; i++ )
                combinacion[i].Text = Convert.ToString(miLoto.Nums[i]);
        }

        private void btValidar_Click(object sender, EventArgs e)
        {
            int[] nums = new int[MAX_NUMEROS];    
            for (int i = 0; i < MAX_NUMEROS; i++)
                nums[i] = Convert.ToInt32(combinacion[i].Text);
            miLoto = new MTB2223(nums);
            if (miLoto.Ok)
                MessageBox.Show("Combinación válida");
            else
                MessageBox.Show("Combinación no válida");
        }

        private void btComprobar_Click(object sender, EventArgs e)
        {
            int[] nums = new int[MAX_NUMEROS];
            for (int i = 0; i < MAX_NUMEROS; i++)
                nums[i] = Convert.ToInt32(combinacion[i].Text);
            miLoto = new MTB2223(nums);
            if (miLoto.Ok)
            {
                nums = new int[MAX_NUMEROS];
                for (int i = 0; i < MAX_NUMEROS; i++)
                    nums[i] = Convert.ToInt32(combinacion[i].Text);
                int aciertos = miGanadora.Comprobar(nums);
                if (aciertos < 3)
                    MessageBox.Show("No ha resultado premiada");
                else
                    MessageBox.Show("¡Enhorabuena! Tiene una combinación con " + Convert.ToString(aciertos) + " aciertos");
            }
            else
                MessageBox.Show("La combinación introducida no es válida");
        }
    }
}
