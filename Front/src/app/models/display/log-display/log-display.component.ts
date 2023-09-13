import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-log-display',
  templateUrl: './log-display.component.html',
  styleUrls: ['./log-display.component.css'],
})
export class LogDisplayComponent {
  @Input() creationName = '';
  @Input() creationDate = '';
  @Input() changeName = '';
  @Input() changeDate = '';
  @Input() id = '';
  @Input() code = '';
}
