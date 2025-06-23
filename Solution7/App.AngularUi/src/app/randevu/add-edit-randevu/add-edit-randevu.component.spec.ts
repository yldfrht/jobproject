import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditRandevuComponent } from './add-edit-randevu.component';

describe('AddEditRandevuComponent', () => {
  let component: AddEditRandevuComponent;
  let fixture: ComponentFixture<AddEditRandevuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddEditRandevuComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditRandevuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
