import React from 'react';

const FooterSection = () => {
  const year = new Date().getFullYear();

  return (
    <footer class="bg-primary main-footer">
      <div class="text-center text-white pt-2">
        <div class="container">
          <h5 className="d-inline-block mr-5">GeekMotors</h5>
          <p className="d-inline-block">Copyright {year} under GPL v3.</p>
        </div>
      </div>
    </footer>
  );
};

export default FooterSection;
