import React, { Fragment } from 'react';

const FlexPicture = ({ id, filename, label, onSelected }) => {
  return (
    <Fragment>
      <div
        id={id}
        className="flex-item bg-white border border-secondary rounded m-2"
      >
        <a onClick={() => onSelected(id)} className="clickable">
          <img src={`images/${filename}`} alt="" className="m-2" />
          <p className="d-block flex-label">{label}</p>
        </a>
      </div>
    </Fragment>
  );
};

export default FlexPicture;
