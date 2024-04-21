import { AfterViewInit, Component } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css'],
})
export class LayoutComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    const scripts = [
      'assets/plugins/jquery/jquery.min.js',
      'assets/plugins/jquery-ui/jquery-ui.min.js',
      'assets/plugins/bootstrap/js/bootstrap.bundle.min.js',
      'assets/plugins/jqvmap/jquery.vmap.min.js',
      'assets/plugins/jqvmap/maps/jquery.vmap.usa.js',
      'assets/plugins/jquery-knob/jquery.knob.min.js',
      'assets/plugins/moment/moment.min.js',
      'assets/plugins/daterangepicker/daterangepicker.js',
      'assets/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js',
      'assets/plugins/summernote/summernote-bs4.min.js',
      'assets/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js',
      'assets/dist/js/adminlte.js',
      'assets/dist/js/demo.js',
    ];

    scripts.forEach((script) => {
      const scriptElement = document.createElement('script');
      scriptElement.src = script;
      document.body.appendChild(scriptElement);
    });
  }
}
