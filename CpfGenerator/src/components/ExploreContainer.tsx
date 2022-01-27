import './ExploreContainer.css';
import React, { useState } from 'react';
import { IonInput, IonItem, IonButton } from '@ionic/react';
import { CpfGenerator } from '../services/CpfGenerator';

interface ContainerProps { }

const ExploreContainer: React.FC<ContainerProps> = () => {
  const [text, setText] = useState<string>();
  const cpfGenerator = new CpfGenerator();

  return (
    <div className="container">
      <div className="div">
        <strong>CPF Gerado</strong>
      </div>
      <div className="div">
        <IonItem>
          <IonInput value={text} placeholder="Aguardando gerar novo CPF" disabled={true}></IonInput>
        </IonItem>
      </div>
      <div className="div">
        <IonButton expand="full" onClick={e => setText(cpfGenerator.run())}>Gerar CPF</IonButton>
      </div>
      <div className="div">
        <IonButton color="danger" expand="full" onClick={e => setText('')}>Limpar</IonButton>
      </div>
    </div>
  );
};

export default ExploreContainer;
