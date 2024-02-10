import { Component } from '@angular/core';
interface Table {
  items: string[];
  name: string;
}


@Component({
  selector: 'app-boards',
  templateUrl: './boards.component.html',
  styleUrl: './boards.component.css'
})
export class BoardsComponent {
  tables: Table[] = [
    { name: 'Todo', items: ['Task1(complete bug)', 'Task2(attend the meeting)', 'Task3(submit the files)','Task4(assemble in boardroom)','Task5(submit the documents)'] },
    { name: 'In Progress', items: [] },
    { name: 'ReOpen', items: [] },
    { name: 'Fixed', items: [] },
    { name: 'Done', items: [] }
  ];

  allowDrop(event: Event): void {
    event.preventDefault();
  }

  drag(event: DragEvent, item: string): void {
    event.dataTransfer?.setData("text/plain", item);
  }

  drop(event: DragEvent, destinationTableIndex: number): void {
    event.preventDefault();
    const data = event.dataTransfer?.getData("text/plain");

    if (data !== undefined) {
      const sourceTableIndex = this.findSourceTableIndex(data);

      if (sourceTableIndex !== -1) {
        this.tables[sourceTableIndex].items = this.tables[sourceTableIndex].items.filter(item => item !== data);
        this.tables[destinationTableIndex].items.push(data);
      }
    }
  }

  private findSourceTableIndex(item: string): number {
    for (let i = 0; i < this.tables.length; i++) {
      if (this.tables[i].items.includes(item)) {
        return i;
      }
    }
    return -1;
  }


}
