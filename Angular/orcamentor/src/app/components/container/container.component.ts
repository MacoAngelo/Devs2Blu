import { Component, Input } from '@angular/core';
import { ContatoComponent } from '../contato/contato.component';

@Component({
  selector: 'app-container',
  standalone: true,
  imports: [ContatoComponent],
  templateUrl: './container.component.html',
  styleUrl: './container.component.css'
})
export class ContainerComponent {
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
