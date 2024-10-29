using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuHelloWorld
{
    public interface IAutenticavel
    {
        void Autenticar();
        void Deslogar();
    }

    public interface IMotor
    {
        void Ligar();
        void Desligar();
    }

    public interface ICambioManual
    {
        void ColocarMarchaAcima();
        void ColocarMarchaAbaixo();
    }

    public class UsuarioSistema : IAutenticavel
    {
        public void Autenticar()
        {
            Console.WriteLine("Usuário autenticado!");
        }

        public void Deslogar()
        {
            Console.WriteLine("Usuário desconectado!");
        }
    }

    public class Gol : Carro, IMotor, ICambioManual
    {
        public void ColocarMarchaAbaixo()
        {
            Console.WriteLine("Trocou a marcha!");
        }

        public void ColocarMarchaAcima()
        {
            Console.WriteLine("Trocou a marcha!");
        }

        public void Desligar()
        {
            Console.WriteLine("Desligando motor...");
        }

        public void Ligar()
        {
            Console.WriteLine("Ligando motor...");
        }
    }

    public enum DiasSemana
    {
        Domingo = 1,
        Segunda = 2,
        Terca = 3,
        Quarta = 4,
        Quinta = 5,
        Sexta = 6,
        Sabado = 7
    }

    public class Produto
    {
        public string Nome;
        public double Preco;
        public int QuantidadeEstoque;

        public Produto()
        {

        }

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            QuantidadeEstoque = quantidade;
        }

        public static string FormatarValor(double valor)
        {
            //return valor.ToString("C");
            return "R$ " + valor.ToString("N");
        }

        public void AtualizarEstoque(int quantidade)
        {
            QuantidadeEstoque = quantidade;
        }

        public void ExibirInfo()
        {
            Console.WriteLine($"Dados do produto");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Preço: {Preco}");
            Console.WriteLine($"Quantidade em estoque: {QuantidadeEstoque}");
        }
    }

    public class ContaBancaria
    {
        private static int _QtdContas = 0;
        // public int QtdContas { get => _QtdContas; }
        public static int QtdContas
        {
            get
            {
                return _QtdContas;
            }
        }

        public string Titular;
        public double Saldo;

        public ContaBancaria()
        {
            _QtdContas++;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Console.WriteLine($"Valor de {valor} depositado!");
        }

        public void Sacar(double valor)
        {
            if (Saldo < valor)
            {
                Console.WriteLine("Saque não realizado!");
            }
            else
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado!");
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Sua conta possui o saldo de {Saldo}");
        }
    }

    public class Carro
    {
        public const int PORCENTAGEM_RESERVA = 20;
        public const int VELOCIDADE_MAXIMA = 80;

        public string Modelo;
        public int Ano;
        public int TanqueLimite;
        public int TanqueAtual;

        private int _Velocidade = 30;
        private int Velocidade
        {
            get
            {
                if (_Velocidade > VELOCIDADE_MAXIMA)
                {
                    return VELOCIDADE_MAXIMA;
                }

                return _Velocidade;
            }
        }

        // ctor + TAB
        public Carro()
        {
        }

        public Carro(string Modelo)
        {
            this.Modelo = Modelo;
        }

        public Carro(string modelo, int ano)
        {
            Modelo = modelo;
            Ano = ano;
        }

        public void Info()
        {
            Console.WriteLine($"Carro de modelo {Modelo} e ano {Ano}. Percorrendo na velocidade {Velocidade}");
        }

        public void Acelerar(int velocidade, out int velocidadeAtual)
        {
            _Velocidade += velocidade;
            velocidadeAtual = Velocidade;
        }

        public bool Reserva()
        {
            var porcentagemLimite = (TanqueLimite / 100) * PORCENTAGEM_RESERVA;
            Console.WriteLine("Dados do tanque:");
            Console.WriteLine($"20%: {porcentagemLimite}");
            Console.WriteLine($"Atual: {TanqueAtual}");

            return TanqueAtual < porcentagemLimite;
        }
    }

    public class Mamifero
    {
        public string Nome;
        public string NomeCientifico;
        public int Idade;

        public void Info()
        {
            Console.WriteLine($"Os dados do animal são:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Nome científico: {NomeCientifico}");
            Console.WriteLine($"Idade: {Idade}");
        }

        public void Respirar()
        {
            Console.WriteLine("O animal está respirando");
        }
    }

    public class Livro
    {
        public string Nome;
        public string Autor;
    }

    public class Calculadora
    {
        public decimal Somar(decimal valor1, decimal valor2)
        {
            return valor1 + valor2;
        }

        public decimal Subtrair(decimal valor1, decimal valor2)
        {
            return valor1 - valor2;
        }
    }

    public class Pessoa
    {
        private static int _ContagemPessoasCadastradas = 0;
        public static int ContagemPessoasCadastradas { get => _ContagemPessoasCadastradas; }

        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa()
        {
            _ContagemPessoasCadastradas++;
        }
    }

    public class Produto2
    {
        private string Nome;
        private decimal Preco;

        public void AlterarNome(string novoNome)
        {
            Nome = novoNome;
            Console.WriteLine("Nome alterado!");
        }

        public void AlterarPreco(decimal novoPreco)
        {
            if (novoPreco > 0)
            {
                Preco = novoPreco;
                Console.WriteLine("Preço alterado!");
            }
            else
            {
                Console.WriteLine("Preço não alterado!");
            }
        }

        public override string ToString()
        {
            return $"Dados do Produto\nNome: {Nome};\nPreço: {Preco}";
        }
    }

    public class Veiculo
    {
        public int Velocidade { get; set; }

        public void Mover()
        {
            Console.WriteLine("O veículo está se movendo");
        }
    }

    public class  Carro2 : Veiculo
    {
        public int QtdPortas { get; set; }

        public void Buzinar()
        {
            Console.WriteLine("Bee!");
        }
    }

    public class Animal
    {
        protected string Som { get; set; }

        public void EmitirSom()
        {
            Console.WriteLine($"O animal está emitindo o som: {Som}");
        }
    }

    public class Cachorro : Animal
    {
        public Cachorro()
        {
            Som = "Au";
        }
    }

    public class Gato : Animal
    {
        public Gato()
        {
            Som = "Miau";
        }
    }

    public class Marreco : Animal
    {
        public Marreco()
        {
            Som = "Quak";
        }
    }

    public class InstrumentoMusical
    {
        protected string Som {get;set;}

        public void Tocar()
        {
            Console.WriteLine($"O instrumento fazendo o som {Som}");
        }
    }

    public class Tambor : InstrumentoMusical
    {
        public Tambor()
        {
            Som = "PUM";
        }
    }

    public class Violao : InstrumentoMusical
    {
        public Violao()
        {
            Som = "BLE";
        }
    }

    public abstract class RegistroDB
    {

        protected abstract string NomeTabela { get; }

        public void Select()
        {
            var select = $"SELECT * FROM {NomeTabela}";

            Console.WriteLine($"Executando select no bando de dados: {select}");
        }
    }

    public class PessoaDB : RegistroDB
    {
        protected override string NomeTabela { get => "PESSOAS"; }
    }

    public class ProdutoDB : RegistroDB
    {
        // protected override string NomeTabela => "PRODUTOS";
        protected override string NomeTabela { get => "PRODUTOS"; }
    }

    public abstract class Forma
    {
        public int Base { get; set; }
        public int Altura { get; set; }

        public abstract void CalcularPerimetro();
    }

    public class Triangulo : Forma
    {
        // base => Palavra reservada -> Precisa colocar @
        public Triangulo(int @base, int altura)
        {
            Base = @base;
            Altura = altura;
        }

        public override void CalcularPerimetro()
        {
            Console.WriteLine($"O resultado do calculo é {(Base * Altura) / 2}");
        }
    }

    public class Retangulo : Forma
    {
        // base => Palavra reservada -> Precisa colocar @
        public Retangulo(int @base, int altura)
        {
            Base = @base;
            Altura = altura;
        }

        public override void CalcularPerimetro()
        {
            Console.WriteLine($"O resultado do calculo é {Base * Altura}");
        }
    }

    public class Executor
    {
        public static void Executar()
        {
            //// Construção usando construtor padrão
            //var carro1 = new Carro();
            //carro1.Modelo = "Clio";
            //carro1.Ano = 1995;
            //carro1.TanqueLimite = 100;
            //carro1.TanqueAtual = 21;

            //// Construção usando construtor padrão + construtor de objetos C#
            //var carro2 = new Carro()
            //{
            //    Modelo = "HB20",
            //    Ano = 2022,
            //    TanqueLimite = 100,
            //    TanqueAtual = 9,
            //};

            //var carro3 = new Carro("Fusca", 1976);

            //var carro4 = new Carro("Gol");

            //carro1.Info();
            //Console.WriteLine(string.Empty);
            //carro2.Info();
            //Console.WriteLine(string.Empty);
            //carro3.Info();
            //Console.WriteLine(string.Empty);
            //carro4.Info();


            ////Console.WriteLine($"Carro de modelo {carro.Modelo} e ano {carro.Ano}");
            //Console.WriteLine($"O carro {(carro.Reserva() ? "SIM" : "NÃO")} está na reserva!");

            //var cachorro = new Mamifero();
            //cachorro.Nome = "Pedrinho";
            //cachorro.NomeCientifico = "Cachorrus";
            //cachorro.Idade = 6;

            //cachorro.Info();
            //cachorro.Respirar();

            //var livro = new Livro();
            //livro.Nome = "Senhor dos anéis";
            //livro.Autor = "Token";

            //var calc = new Calculadora();
            //Console.WriteLine(calc.Somar(256, 64));

            //Console.WriteLine($"Existem {Pessoa.ContagemPessoasCadastradas} pessoas cadastradas no sistema!");

            //var p1 = new Pessoa()
            //{
            //    Nome = "João",
            //    Idade = 18,
            //};

            //var p2 = new Pessoa()
            //{
            //    Nome = "Mario",
            //    Idade = 16,
            //};

            //var p3 = new Pessoa()
            //{
            //    Nome = "Maria",
            //    Idade = 23,
            //};

            //p1 = new Pessoa();
            //p1 = new Pessoa();
            //p1 = new Pessoa();
            //p1 = new Pessoa();
            //p1 = new Pessoa();

            //Console.WriteLine($"Existem {Pessoa.ContagemPessoasCadastradas} pessoas cadastradas no sistema!");

            //var c1 = new ContaBancaria();
            //var c2 = new ContaBancaria();
            //var c3 = new ContaBancaria();

            //Console.WriteLine($"Existem {ContaBancaria.QtdContas} contas cadastradas no sistema!");

            //var p1 = new Produto();
            //p1.Preco = 1568.24;

            //Console.WriteLine(Produto.FormatarValor(p1.Preco));

            // Casting
            //DiasSemana numero = (DiasSemana)2;

            //numero = DiasSemana.Quarta;

            //switch (numero)
            //{
            //    case DiasSemana.Domingo:
            //        Console.WriteLine("É doming");
            //        break;
            //    case DiasSemana.Segunda:
            //        Console.WriteLine("É segunda-feira");
            //        break;
            //    case DiasSemana.Terca:
            //        Console.WriteLine("É terça-feira");
            //        break;
            //    case DiasSemana.Quarta:
            //        Console.WriteLine("É quarta-feira");
            //        break;
            //    case DiasSemana.Quinta:
            //        Console.WriteLine("É quinta-feira");
            //        break;
            //    case DiasSemana.Sexta:
            //        Console.WriteLine("É sexta-feira");
            //        break;
            //    case DiasSemana.Sabado:
            //        Console.WriteLine("É sabado");
            //        break;
            //    default:
            //        Console.WriteLine("Não conheço esse dia da semana!");
            //        break;
            //}

            //Console.WriteLine($"O número desse elemento do enumerador é {numero.GetHashCode()}");

            //ExibirMensagemConsole("Olá!");

            //int velocidadeFusca = 0;
            //var carro3 = new Carro("Fusca", 1976);
            //carro3.Info();

            //carro3.Acelerar(25, out velocidadeFusca);
            //Console.WriteLine($"Acelerei o Fusca, está em {velocidadeFusca}");

            //carro3.Acelerar(25, out velocidadeFusca);
            //Console.WriteLine($"Acelerei o Fusca, está em {velocidadeFusca}");

            //carro3.Acelerar(250, out velocidadeFusca);
            //Console.WriteLine($"Acelerei o Fusca, está em {velocidadeFusca}");

            //Console.WriteLine(Somar(5, 5, 36, 9, 8, 7, 1, 4, 5, 9));

            //var produto = new Produto2();

            //produto.AlterarNome("Geladeira Gamer");
            //produto.AlterarPreco(-1000);
            //produto.AlterarPreco(6000);

            //Console.WriteLine(produto.ToString());

            //var carro = new Carro2();
            //carro.Mover();
            //carro.Buzinar();

            //List<Animal> animais = new List<Animal>();

            //animais.Add(new Cachorro());
            //animais.Add(new Gato());
            //animais.Add(new Cachorro());
            //animais.Add(new Gato());
            //animais.Add(new Gato());
            //animais.Add(new Cachorro());
            //animais.Add(new Marreco());

            //foreach (var animal in animais)
            //{
            //    animal.EmitirSom();
            //}

            //var instrumentos = new InstrumentoMusical[3];

            //instrumentos[0] = new Violao();
            //instrumentos[1] = new Tambor();
            //instrumentos[2] = new Violao();

            //foreach(var instrumento in instrumentos)
            //{
            //    instrumento.Tocar();
            //}

            var triangulo = new Triangulo(2, 5);
            var retangulo = new Retangulo(5, 9);

            triangulo.CalcularPerimetro();
            retangulo.CalcularPerimetro();
        }


        public static void ExibirMensagemConsole(string mensagem1, string mensagem2 = "NADA!")
        {
            Console.WriteLine(mensagem1);
            Console.WriteLine(mensagem2);
        }

        public static int Somar(params int[] numeros)
        {
            int resultado = 0;

            foreach (int numero in numeros)
            {
                resultado += numero;
            }

            return resultado;
        }
    }
}
