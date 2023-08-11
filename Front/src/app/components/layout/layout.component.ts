import { Component } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css'],
})
export class LayoutComponent {
  showLayout: boolean = false;

  appitems = [
    {
      label: 'Início',
      icon: 'home',
    },
    {
      label: 'Clientes',
      icon: 'folder_shared',
      items: [
        {
          label: 'Clientes',
          icon: 'folder_shared',
        },
        {
          label: 'Status',
          icon: 'flag',
        },
        {
          label: 'Configurações',
          icon: 'settings',
        },
      ],
    },
  ];

  config = { fontColor: '#5e5e5e' };

  constructor() {}

  ngOnInit() {}

  selectedItem($event: any) {
    console.log($event);
  }
}
