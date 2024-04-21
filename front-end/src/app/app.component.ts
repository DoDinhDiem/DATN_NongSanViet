import { AfterViewInit, Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements AfterViewInit {
  ngAfterViewInit() {
    // Tạo phần tử script cho các thư viện bạn muốn sử dụng
    const scripts = [
      'assets/lib/jquery/jquery-1.11.2.min.js',
      'assets/lib/jquery-migrate.min.js',
      'assets/lib/fancyBox/source/jquery.fancybox.pack.js',
      'assets/lib/bootstrap/js/bootstrap.min.js',
      'assets/lib/select2/js/select2.min.js',
      'assets/lib/jquery.bxslider/jquery.bxslider.min.js',
      'assets/lib/owl.carousel/owl.carousel.min.js',
      'assets/js/jquery.actual.min.js',
      'assets/js/theme-script.js',
      // 'assets/js/shoppingCart.js',
      'assets/js/layout.js',
    ];
    // Lặp qua từng script và thêm chúng vào thẻ body
    scripts.forEach((src) => {
      const script = document.createElement('script');
      script.src = src;
      document.body.appendChild(script);
    });
  }
}
