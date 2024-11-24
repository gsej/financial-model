import { CommonModule } from '@angular/common';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-popup',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './popup.component.html',
})
export class PopupComponent implements OnInit {

  @ViewChild('dialog', { static: false }) dialogElementRef!: ElementRef;
 // @ViewChild('dialog') dialogElementRef!: ElementRef;

  @Input()
  id: string = 'trigger';

  @Input()
  visible: boolean = false;

  getTriggerPosition(): { top: number, left: number } | null {
    const triggerElement = document.getElementById(this.id);
    if (triggerElement) {
      const rect = triggerElement.getBoundingClientRect();
      return {
        top: rect.top + window.scrollY,
        left: rect.left + window.scrollX
      };
    }
    return null;
  }

  @Input()
  class: string = '';

  size = 'small';

  width = '';

  @Input()
  click: () => void = () => { };

  ngOnInit(): void {
    if (this.size === 'small') {
      this.width = 'w-[50em]';
    }
  }

  toggle() {
    console.log('toggle');

    if (!this.visible){

    const position = this.getTriggerPosition();
    if (this.dialogElementRef && position) {
      this.dialogElementRef.nativeElement.style.top = `${position.top + 20}px`;
      this.dialogElementRef.nativeElement.style.left = `${position.left + 20}px`;
    }

      this.visible = true;
    }
    else {
      this.visible = false;
    }





  }
}
