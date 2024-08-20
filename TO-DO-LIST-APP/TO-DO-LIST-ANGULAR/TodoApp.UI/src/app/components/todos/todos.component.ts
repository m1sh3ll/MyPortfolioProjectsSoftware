import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { TodoService } from '../../services/todo.service';
import { NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-todos',
  standalone: true,
  imports: [NgFor,FormsModule, DatePipe],
  templateUrl: './todos.component.html',
  styleUrl: './todos.component.css'
})
export class TodosComponent implements OnInit {
  todos: Todo[] = [];
  newTodo: Todo = {
    id: '',
    description: '',
    createdDate: new Date(),
    isCompleted: false,
    completedDate: new Date()
  };

  constructor(private todoService: TodoService) {

  }


  ngOnInit(): void {
    this.getAllTodos();
  }

  getAllTodos() {
    this.todoService.getAllTodos()
      .subscribe({
        next: (todos) => {
          this.todos = todos;
        }
      });
  }


  addToDo() {
    this.todoService.addTodo(this.newTodo)
      .subscribe({
        next: (todo) => {
          this.getAllTodos();
        }
      });
  }

  deleteTodo(id:string) {
    this.todoService.deleteTodo(id)
      .subscribe({
        next: (response) => {
          this.getAllTodos();
        }
      });
  }

  onCompletedChange(id: string, todo: Todo) {
    //debugger
    todo.isCompleted = !todo.isCompleted;
    this.todoService.updateTodo(id, todo)
      .subscribe({
        next: (response) => {
          this.getAllTodos();
        }
      });
  }
}
