import React, { Fragment, PropsWithChildren } from 'react';
import ReactDOM from 'react-dom';

import classes from './Model.module.css';

interface BackdropProps {
  onClose: () => void;
}

const Backdrop: React.FC<BackdropProps> = (props) => {
  return <div className={classes.backdrop} onClick={props.onClose} />;
};

const ModalOverlay: React.FC<PropsWithChildren> = (props) => {
  return (
    <div className={classes.modal}>
      <div className={classes.content}>{props.children}</div>
    </div>
  );
};

interface ModalProps extends PropsWithChildren {
  onClose: () => void;
}

const Modal: React.FC<ModalProps> = (props) => {
  const portalElement = document.getElementById('overlays');

  if (!portalElement) {
    throw new Error('Unable to find element with ID "overlays"');
  }

  return (
    <Fragment>
      {ReactDOM.createPortal(<Backdrop onClose={props.onClose} />, portalElement)}
      {ReactDOM.createPortal(
        <ModalOverlay>{props.children}</ModalOverlay>,
        portalElement
      )}
    </Fragment>
  );
};

export default Modal;