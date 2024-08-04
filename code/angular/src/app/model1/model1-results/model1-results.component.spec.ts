import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Model1ResultsComponent } from './model1-results.component';

describe('Model1ResultsComponent', () => {
  let component: Model1ResultsComponent;
  let fixture: ComponentFixture<Model1ResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Model1ResultsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Model1ResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
