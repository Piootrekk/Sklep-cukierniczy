import React, { PropsWithChildren, createContext, useContext, useState } from 'react';

interface StepperContextData {
    activeStep: number;
    skipped: Set<number>;
    isStepOptional: (step: number) => boolean;
    isStepSkipped: (step: number) => boolean;
    handleNext: () => void;
    handleBack: () => void;
    handleSkip: () => void;
    handleReset: () => void;
}

const StepperContext = createContext<StepperContextData>({} as StepperContextData);

const StepperProvider: React.FC<PropsWithChildren> = ({ children }) => {
    const [activeStep, setActiveStep] = useState(0);
    const [skipped, setSkipped] = useState(new Set<number>());

    const isStepOptional = (step: number) => {
        return step === 1;
    };

    const isStepSkipped = (step: number) => {
        return skipped.has(step);
    };

    const handleNext = () => {
        let newSkipped = skipped;
        if (isStepSkipped(activeStep)) {
            newSkipped = new Set(newSkipped.values());
            newSkipped.delete(activeStep);
        }

        setActiveStep((prevActiveStep) => prevActiveStep + 1);
        setSkipped(newSkipped);
    };

    const handleBack = () => {
        setActiveStep((prevActiveStep) => prevActiveStep - 1);
    };

    const handleSkip = () => {
        if (!isStepOptional(activeStep)) {
            throw new Error("You can't skip a step that isn't optional.");
        }

        setActiveStep((prevActiveStep) => prevActiveStep + 1);
        setSkipped((prevSkipped) => {
            const newSkipped = new Set(prevSkipped.values());
            newSkipped.add(activeStep);
            return newSkipped;
        });
    };

    const handleReset = () => {
        setActiveStep(0);
    };

    const appContextData: StepperContextData = {
        activeStep,
        skipped,
        isStepOptional,
        isStepSkipped,
        handleNext,
        handleBack,
        handleSkip,
        handleReset,
    };

    return (
        <StepperContext.Provider value={appContextData}>
            {children}
        </StepperContext.Provider>
    );
};

const useStepperContext = () => useContext(StepperContext);

export { StepperProvider, useStepperContext };