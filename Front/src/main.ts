import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enviroments } from 'src/environments/environments';

import { AppModule } from './app/app.module';
import { enableProdMode } from '@angular/core';

platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch((err) => console.error(err));
