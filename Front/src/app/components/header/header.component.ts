import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { BreakpointObserver } from '@angular/cdk/layout';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  @ViewChild(MatSidenav) sidenav!: MatSidenav;

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

  constructor(public route: Router, private observer: BreakpointObserver) {}

  ngAfterViewinit() {
    this.observer.observe(['{max-width: 800px}']).subscribe((res) => {
      if (res.matches) {
        this.sidenav.mode = 'over';
        this.sidenav.close();
      } else {
        this.sidenav.mode = 'side';
        this.sidenav.open();
      }
    });
  }

  ngOnInit() {}

  selectedItem($event: any) {
    var routeName = $event.link;
    this.route.navigate([routeName]);
  }
}
