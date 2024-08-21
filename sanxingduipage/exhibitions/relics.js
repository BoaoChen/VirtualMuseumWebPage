  // 获取当前页面的URL路径
  const currentPath = window.location.pathname;

  // 获取所有导航链接
  const navLinks = document.querySelectorAll('#relics-artifact-nav a');

  // 遍历链接并设置活动状态
  navLinks.forEach(link => {
      if (currentPath.includes(link.getAttribute('href'))) {
          link.classList.add('active');
      } else {
          link.classList.remove('active');
      }
  });

  // 添加点击事件监听器
  navLinks.forEach(link => {
      link.addEventListener('click', function(e) {
          // 移除所有链接的活动状态
          navLinks.forEach(l => l.classList.remove('active'));
          // 为点击的链接添加活动状态
          this.classList.add('active');
      });
  });