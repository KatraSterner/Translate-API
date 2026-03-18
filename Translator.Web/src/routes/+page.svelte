<script lang="ts">
    // NOTE: Claude AI used for styling 
    
    let userPrompt = $state("Hello"); // TODO: remove - temporary for testing
    let result = $state<{ prompt: string, translation: string } | null>(null);
    let selectedLanguage = $state("");
    
    async function handleSubmit(e: Event) {
        e.preventDefault();
        
        const response = await fetch("http://localhost:5006/api/translate", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ prompt: userPrompt, targetLanguage: selectedLanguage }),
        });

        result = await response.json();
    }
    
</script>

<main class="min-h-screen bg-gray-50 flex items-start justify-center pt-16 px-4">
    
    <div class="w-full max-w-lg">

        <div class="flex items-baseline gap-3 mb-8">
            <h1 class="text-3xl font-serif font-normal tracking-tight text-gray-900">
                dotNET Translator
            </h1>
            <span class="text-xs uppercase tracking-widest text-gray-400 font-mono">
                GTranslate - v2.3.1
            </span>
        </div>

        <div class="bg-white border border-gray-200 rounded-xl p-6 shadow-sm">
            
            <form onsubmit={handleSubmit} class="space-y-4">
                <div class="flex flex-col gap-1.5">
                    <label class="text-xs uppercase tracking-widest text-gray-400 font-mono" for="language">
                        Target language
                    </label>
                    <select
                            required
                            name="language"
                            bind:value={selectedLanguage}
                            class="w-full border border-gray-200 rounded-lg px-3 py-2 text-sm font-mono bg-gray-50 text-gray-800 focus:outline-none focus:ring-2 focus:ring-gray-300"
                    >
                        <option value="" disabled hidden>Select target language...</option>
                        <option value="en">English</option>
                        <option value="es">Spanish</option>
                        <option value="ja">Japanese</option>
                        <option value="fr">French</option>
                        <option value="de">German</option>
                        <option value="it">Italian</option>
                    </select>
                </div>

                <div class="flex flex-col gap-1.5">
                    <label class="text-xs uppercase tracking-widest text-gray-400 font-mono" for="prompt">
                        Prompt
                    </label>
                    <input
                            name="prompt"
                            type="text"
                            required
                            bind:value={userPrompt}
                            placeholder="Enter text to translate..."
                            class="w-full border border-gray-200 rounded-lg px-3 py-2 text-sm font-mono text-gray-800 placeholder-gray-300 focus:outline-none focus:ring-2 focus:ring-gray-300"
                    />
                </div>

                <button
                        type="submit"
                        class="w-full mt-1 py-2.5 border border-gray-300 rounded-lg text-xs uppercase tracking-widest font-mono text-gray-700 hover:bg-gray-50 active:scale-[0.98] transition-all"
                >
                    Translate →
                </button>
            </form>

            <hr class="my-5 border-gray-100" />

            <div class="space-y-2">
                <div class="flex gap-4 items-baseline py-1">
                    <span class="text-xs uppercase tracking-widest text-gray-400 font-mono min-w-[90px]">
                        Prompt
                    </span>
                    <span class="text-sm text-gray-800 font-mono">
                        {#if result?.prompt}
                            <span class="text-gray-500">— {result?.prompt}</span>
                        {/if}
                    </span>
                </div>
                <div class="flex gap-4 items-baseline py-1">
                    <span class="text-xs uppercase tracking-widest text-gray-400 font-mono min-w-[90px]">
                        Translation
                    </span>
                    <span class="text-sm text-gray-800 font-mono">
                        {#if result?.translation}
                            <span class="text-gray-500">— {result?.translation}</span>
                            
                        {/if}
                    </span>
                </div>
            </div>
            
        </div>
    </div>
</main>