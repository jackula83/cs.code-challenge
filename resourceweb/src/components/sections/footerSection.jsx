import React from 'react';

const FooterSection = () => {
  const year = new Date().getFullYear();

  return (
    <footer className="bg-primary main-footer">
      <div className="text-center text-white pt-2">
        <div className="container">
          <h5 className="d-inline-block mr-5">GeekMotors</h5>
          <p className="d-inline-block">Copyright {year} under GPL v3.</p>
        </div>
      </div>
    </footer>
  );
};

export default FooterSection;
