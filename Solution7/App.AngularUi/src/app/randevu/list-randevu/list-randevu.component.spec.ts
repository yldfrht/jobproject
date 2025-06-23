import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListRandevuComponent } from './list-randevu.component';

describe('ListRandevuComponent', () => {
  let component: ListRandevuComponent;
  let fixture: ComponentFixture<ListRandevuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListRandevuComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListRandevuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
