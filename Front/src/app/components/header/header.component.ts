import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  showHeader: boolean = false;

  appitems = [
    {
      label: 'Início',
      icon: 'home',
      link: '/',
    },
    {
      label: 'Clientes',
      icon: 'folder_shared',
      items: [
        {
          label: 'Clientes',
          icon: 'folder_shared',
          link: '/customers',
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

  constructor(public route: Router) {}

  ngOnInit() {}

  selectedItem($event: any) {
    var routeName = $event.link;
    this.route.navigate([routeName]);
  }
}
