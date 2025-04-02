import { Component, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContatoComponent } from '../contato/contato.component';

@Component({
  selector: 'app-container',
  standalone: true,
  imports: [ContatoComponent],
  templateUrl: './container.component.html',
  styleUrl: './container.component.css'
})
export class ContainerComponent {
  dados:any;

  constructor(private http: HttpClient)  {}

  ngOnInit():void {
    this.obterPrevisoes();
  }

  obterPrevisoes():void {
    let url = "http://localhost:5048/WeatherForecast";
    this.http.get(url).subscribe({
      // Funcionou a requisição
      next: (response) => {
        this.dados = response;
        console.log(this.dados);
      },
      // Deu ruim!
      error: (erro) => {
        alert("Deu ruim!");
        console.log(`Erro ao obter as previsões: ${erro}`)
      }
    });
  }

  // obterDados():void {
  //   let endpoint = "https://localhost:7299/WeatherForecast";
  //   this.http.get(endpoint).subscribe({
  //     next: (response) =>{
  //       this.dados = response;
  //       console.log(this.dados);
  //     },
  //     error: (erro) => {
  //       console.log('Erro ao obter dados: ' + erro)
  //     }
  //   });
  // }

  removeItem(index: number) {
    this.contatos.splice(index, 1);
  }

  addItem() {
    this.contatos.push({ nome: "Novo contato", email: " ", telefone: " " })
  }

  @Input() titulo: string = '';
  @Input() descricao: string = '';
  @Input() notaRodape: string = 'Bolinha';

  contatos: Array<ContatoComponent> = [
    {
      nome: "Marco Antonio Angelo",
      email: "marco.angelo@gmail.com",
      telefone: "(47) 99171-0879"
    },
    {
      nome: "José da Silva",
      email: "jose.silva@gmail.com",
      telefone: "(47) 99171-0879"
    },
    {
      nome: "Maria Antonio",
      email: "maria.antonio@gmail.com",
      telefone: "(47) 99171-0879"
    },
    {
      nome: "Catarina Bailarina",
      email: "catarina.bailarina@gmail.com",
      telefone: "(47) 99171-0879"
    }
  ]
}