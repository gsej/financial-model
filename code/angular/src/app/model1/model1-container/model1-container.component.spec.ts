import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Model1ContainerComponent } from './model1-container.component';

describe('Model1ContainerComponent', () => {
  let component: Model1ContainerComponent;
  let fixture: ComponentFixture<Model1ContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Model1ContainerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Model1ContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
