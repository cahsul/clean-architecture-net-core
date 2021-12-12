function Onload(url) {
  var navClass = 'nav-sidebar',
      navItemClass = 'nav-item',
      navLinkClass = 'nav-link',
      navSubmenuClass = 'nav-group-sub',
      navScrollSpyClass = 'nav-scrollspy';
  var checkExist = setInterval(function () {
    $('.' + navClass + ':not(.' + navScrollSpyClass + ')').each(function () {
      console.log($(this).find('.' + navItemClass).has('.' + navSubmenuClass).children('.' + navItemClass + ' > ' + '.' + navLinkClass).not('.disabled').length);

      if ($(this).find('.' + navItemClass).has('.' + navSubmenuClass).children('.' + navItemClass + ' > ' + '.' + navLinkClass).not('.disabled').length > 0) {
        App.initNavigations();
        clearInterval(checkExist);
      }
    });
  }, 1000);
}

export { Onload };
