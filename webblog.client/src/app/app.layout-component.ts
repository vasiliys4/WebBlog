import { Component, HostListener, AfterViewInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './app.layout-component.html',
  styleUrls: ['./app.layout-component.scss']
})
export class LayoutComponent implements AfterViewInit {
  isMobile = false;
  isAuthenticated = false; // заменить логикой авторизации

  constructor(private el: ElementRef) {
    this.checkScreenSize();
  }

  @HostListener('window:resize')
  checkScreenSize() {
    this.isMobile = window.innerWidth < 768;
  }

  login() {
    this.isAuthenticated = true; // пример
  }

  logout() {
    this.isAuthenticated = false; // пример
  }

  ngAfterViewInit() {
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            entry.target.classList.add('fade-in-up');
            observer.unobserve(entry.target);
          }
        });
      },
      { threshold: 0.1 }
    );

    const elements = this.el.nativeElement.querySelectorAll('.fade-element');
    elements.forEach((el: Element) => observer.observe(el));
  }
}

